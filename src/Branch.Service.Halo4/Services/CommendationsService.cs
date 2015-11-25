using System.Threading.Tasks;
using Branch.Helpers.Services;
using Microsoft.Extensions.Logging;
using Branch.Service.Halo4.Database;
using Branch.Service.Halo4.DocumentDb;
using System;
using Microsoft.Halo.Core.DataContracts;
using Branch.Service.Halo4.Database.Repositories.Interfaces;
using System.Linq;
using Microsoft.Halo.Core.DataContracts.Enums;
using Branch.Service.Halo4.Exceptions;
using Branch.Service.Xuid.Exceptions;
using Branch.Service.Xuid.Services;
using System.Collections.Generic;
using Branch.Service.Halo4.Database.Models;

namespace Branch.Service.Halo4.Services
{
	public class CommendationsService
		: ServiceBase<CommendationsService>
	{
		public CommendationsService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, 
			Halo4DbContext halo4DbContext, Halo4DdbRepository halo4DdbRepository, 
			AuthenticationService authenticationService, IServiceRecordRepository serviceRecordRepository, ICommendationsRepository commendationsRepository)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{
			_serviceRecordRepository = serviceRecordRepository;
			_commendationsRepository = commendationsRepository;
		}

		private IServiceRecordRepository _serviceRecordRepository;

		private ICommendationsRepository _commendationsRepository;

		private const string GetCommendationsUrl = "https://stats.svc.halowaypoint.com/en-GB/players/{0}/h4/commendations";

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(0, 5, 0);

		public async Task<CommendationsDetailsFull> GetCommendations(Int64 xuid)
		{
			return await GetCommendations(xuid, false);
		}

		public async Task<CommendationsDetailsFull> GetCommendations(Int64 xuid, bool takeCached)
		{
			// retrieve gamertag (via xuid) from xuid lookup service
			var playerGamertag = await XuidLookupService.LookupGamertagAsync(xuid);

			var spartanToken = await AuthenticationService.GetSpartanTokenAsync();
			var validAuthentication = spartanToken != null;
			var commendationsUri = new Uri(string.Format(GetCommendationsUrl, playerGamertag));

			// Get Commendations metadata from Database
			var serviceRecordMetadata = _serviceRecordRepository.Where(sr => sr.Xuid == xuid).FirstOrDefault();
			var commendationsMetadata = _commendationsRepository.Where(c => c.ServiceRecordId == serviceRecordMetadata.Id).FirstOrDefault();
			CommendationsDetailsFull cachedCommendations = null;
			if (commendationsMetadata != null)
			{
				// Return data from DocumentDb if we're taking cached version, it's expired, or the auhentication is broken
				if (!validAuthentication || takeCached || commendationsMetadata.UpdatedAt + CacheRefreshTime > DateTime.UtcNow)
				{
					// Get Commendations from DocumentDb
					cachedCommendations = Halo4DdbRepository.GetById<CommendationsDetailsFull>(commendationsMetadata.DocumentId);

					// If the cached Game History exists, return it
					if (cachedCommendations != null)
						return cachedCommendations;
				}
			}

			// If auth is broken, throw exception
			if (!validAuthentication)
				throw new Halo4AuthenticationDownException();

			// Get Game History from 343's Halo Service
			var commendationsResponse = await HttpManagerService.ExecuteRequestAsync<CommendationsDetailsFull>(HttpMethod.GET, commendationsUri, headers:
				new Dictionary<string, string>
				{
					{ "X-343-Authorization-Spartan", spartanToken }
				});

			// Check if something went wrong with the request or parsing
			if (commendationsResponse == null)
				return null; // TODO: find a way to acess this data and throw the relevant exception

			// Check response
			switch (commendationsResponse.StatusCode)
			{
				case StatusCode.NoData:
					throw new PlayerHasntPlayedHalo4Exception();

				case StatusCode.ContentNotFound:
					throw new ContentNotFoundException(commendationsResponse.StatusReason);
			}

			// Update documentdb and return data if it exists in the DocumentDb
			if (commendationsMetadata != null)
				cachedCommendations =
					await Halo4DdbRepository.UpdateAsync<CommendationsDetailsFull>(commendationsMetadata.DocumentId, commendationsResponse);
			else
				cachedCommendations = await Halo4DdbRepository.CreateAsync<CommendationsDetailsFull>(commendationsResponse);

			// Query (or, on fallback, create) Service Record
			var serviceRecord = _serviceRecordRepository.Where(sr => sr.Xuid == xuid).FirstOrDefault();
			if (serviceRecord == null)
				_serviceRecordRepository.Add(new ServiceRecord
				{
					DocumentId = null,
					Xuid = xuid,
					ServiceTag = "YOLO"
				});

			// Query (or, on fallback, create) Commendations
			var commendations = _commendationsRepository
				.Where(c => c.ServiceRecordId == serviceRecordMetadata.Id)
				.FirstOrDefault();
			if (commendations == null)
				_commendationsRepository.Add(new Commendations
				{
					DocumentId = cachedCommendations.Id,
					ServiceRecordId = serviceRecord.Id
				});
			else
			{
				commendations.DocumentId = cachedCommendations.Id;
				_commendationsRepository.Update(commendations);
			}

			// Return Commendations to user
			return cachedCommendations;
		}
	}
}
