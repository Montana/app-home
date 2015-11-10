using System.Threading.Tasks;
using Branch.Helpers.Services;
using Branch.Service.Halo4.Database.Models;
using Microsoft.Framework.Logging;
using Branch.Service.Halo4.Database;
using Branch.Service.Halo4.DocumentDb;
using System;
using Microsoft.Halo.Core.DataContracts;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Enums;
using Branch.Service.Halo4.Database.Repositories.Interfaces;
using Branch.Service.Halo4.Exceptions;
using Branch.Service.Xuid.Services;
using System.Collections.ObjectModel;

namespace Branch.Service.Halo4.Services
{
	public class MatchService
		: ServiceBase<MatchService>
	{
		public MatchService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, Halo4DbContext halo4DbContext, Halo4DdbRepository halo4DdbRepository, AuthenticationService authenticationService, IMatchRepository matchRepository, IServiceRecordRepository serviceRecordRepository)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{
			_serviceRecordRepository = serviceRecordRepository;
			_matchRepository = matchRepository;
		}

		private IServiceRecordRepository _serviceRecordRepository;

		private IMatchRepository _matchRepository;

		private const string GetMatchUrl = "https://stats.svc.halowaypoint.com/en-US/h4/matches/{0}";

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(10, 0, 0, 0, 0);
		
		public async Task<GameDetailsFull> GetMatch(Int64 xuid, string matchId)
		{
			return await GetMatch(xuid, matchId, false);
		}
		
		public async Task<GameDetailsFull> GetMatch(Int64 xuid, string matchId, bool takeCached)
		{
			var playerGamertag = await XuidLookupService.LookupGamertagAsync(xuid);

			var spartanToken = await AuthenticationService.GetSpartanTokenAsync();
			var validAuthentication = spartanToken != null;
			var matchUri = new Uri(string.Format(GetMatchUrl, matchId));

			// Get Match metadata from Database
			var matchMetadata = _matchRepository.Where(m => m.MatchId == matchId).FirstOrDefault();
			GameDetailsFull cachedmatch = null;
			if (matchMetadata != null)
			{
				// Return data from DocumentDb if we're taking cached version, or the auhentication is broken
				if (!validAuthentication || takeCached)
				{
					// Get Match from DocumentDb
					cachedmatch = Halo4DdbRepository.GetById<GameDetailsFull>(matchMetadata.DocumentId);

					// If the cached Match exists, return it
					if (cachedmatch != null)
						return cachedmatch;
				}
			}

			// If auth is broken, throw exception
			if (!validAuthentication)
				throw new Halo4AuthenticationDownException();

			// Get Match from 343's Halo Service
			var matchResponse = await HttpManagerService.ExecuteRequestAsync<GameDetailsFull>(HttpMethod.GET, matchUri, headers:
				new Dictionary<string, string>
				{
					{ "X-343-Authorization-Spartan", spartanToken }
				});

			// Check if something went wrong with the request or parsing
			if (matchResponse == null)
				return null; // TODO: find a way to acess this data and throw the relevant exception

			// Check response
			switch (matchResponse.StatusCode)
			{
				case StatusCode.NoData:
					throw new PlayerHasntPlayedHalo4Exception();

				case StatusCode.ContentNotFound:
					throw new ContentNotFoundException(matchResponse.StatusReason);
			}

			// Update documentdb and return data if it exists in the DocumentDb
			if (matchMetadata != null)
				cachedmatch =
					await Halo4DdbRepository.UpdateAsync<GameDetailsFull>(matchMetadata.DocumentId, matchResponse);
			else
				cachedmatch = await Halo4DdbRepository.CreateAsync<GameDetailsFull>(matchResponse);

			// Query (or, on fallback, create) Service Record
			var serviceRecord = _serviceRecordRepository.Where(sr => sr.Xuid == xuid).FirstOrDefault();
			if (serviceRecord == null)
				serviceRecord = _serviceRecordRepository.Add(new ServiceRecord
				{
					DocumentId = null,
					Xuid = xuid,
					ServiceTag = "YOLO"
				});

			// Query (or, on fallback, create) Game History
			var match = _matchRepository.Where(m => m.MatchId == matchId).FirstOrDefault();
			if (match == null)
				match = _matchRepository.Add(new Match
				{
					DocumentId = cachedmatch.Id,
					MatchId = matchResponse.Game.Id,
					GameMode = matchResponse.Game.Mode
				});
			else
			{
				match.DocumentId = cachedmatch.Id;
				_matchRepository.Update(match);
			}

			if (serviceRecord.ServiceRecordMatches == null || serviceRecord.ServiceRecordMatches.Any(m => m.MatchId == match.Id) == false)
			{
				if (serviceRecord.ServiceRecordMatches == null)
					serviceRecord.ServiceRecordMatches = new Collection<ServiceRecordMatch>();

				serviceRecord.ServiceRecordMatches.Add(new ServiceRecordMatch { Match = match, ServiceRecord = serviceRecord });
				_serviceRecordRepository.Update(serviceRecord);
			}

			// Return Match to user
			return cachedmatch;
		}
	}
}
