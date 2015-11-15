using System.Threading.Tasks;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;
using Branch.Service.Halo5.Database;
using Branch.Service.Halo5.DocumentDb;
using System;
using System.Collections.Generic;
using Branch.Service.Halo5.Database.Repositories.Interfaces;
using System.Linq;
using Branch.Service.Halo5.Models.Api;
using Branch.Service.Halo5.Models.Api.Abstracts;
using Branch.Service.Xuid.Services;

namespace Branch.Service.Halo5.Services
{
	public class ServiceRecordService
		: ServiceBase<ServiceRecordService>
	{
		public ServiceRecordService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, Halo5DbContext halo5DbContext, Halo5DdbRepository halo5DdbRepository, AuthenticationService authenticationService, IServiceRecordRepository serviceRecordRepository)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo5DbContext, halo5DdbRepository, authenticationService)
		{
			_serviceRecordRepository = serviceRecordRepository;
		}

		private readonly IServiceRecordRepository _serviceRecordRepository;

		private const string GetArenaServiceRecordUrl = "https://www.haloapi.com/stats/h5/servicerecords/arena?players={0}";

		private readonly TimeSpan _cacheRefreshTime = new TimeSpan(0, 5, 0);

		public async Task<Response<ServiceRecordResult>> GetArenaServiceRecord(string gamertag)
		{
			return await GetArenaServiceRecord(gamertag, false);
		}

		public async Task<Response<ServiceRecordResult>> GetArenaServiceRecord(string gamertag, bool takeCached)
		{
			// Get Player XUID
			var playerXuid = await XuidLookupService.LookupXuidAsync(gamertag);

			// Get Service Record metadata from Database
			var serviceRecordMetadata = _serviceRecordRepository.Where(sr => sr.Xuid == playerXuid).FirstOrDefault();
			Response<ServiceRecordResult> cachedServiceRecord;
			if (serviceRecordMetadata != null)
			{
				// Return data from DocumentDb if we're taking cached version, or it's expired
				if (takeCached || serviceRecordMetadata.UpdatedAt + _cacheRefreshTime > DateTime.UtcNow)
				{
					// Get Service Record from DocumentDb
					cachedServiceRecord = Halo5DdbRepository.GetById<Response<ServiceRecordResult>>(serviceRecordMetadata.DocumentId);

					// If the cached Service Record exist, return it
					if (cachedServiceRecord != null)
						return cachedServiceRecord;
				}
			}

			// Populate template service record url
			var getServiceRecordUri = new Uri(string.Format(GetArenaServiceRecordUrl, gamertag));

			// Get Service Record from 343's Halo Service
			var serviceRecordResponse = await HttpManagerService.ExecuteRequestAsync<Response<ServiceRecordResult>>(HttpMethod.GET, getServiceRecordUri,
				headers: new Dictionary<string, string>
				{
					{ "Ocp-Apim-Subscription-Key", AuthenticationService.GetAuthentication() }
				});

			// Check if something went wrong with the request or parsing
			if (serviceRecordResponse == null)
				return null; // TODO: find a way to access this data and throw the relevant exception

			// Set XUID value in the response
			serviceRecordResponse.Results.First().Result.PlayerId.Xuid = playerXuid;

			// Update documentdb and return data if it exists in the DocumentDb
			if (serviceRecordMetadata != null)
				cachedServiceRecord = await Halo5DdbRepository.UpdateAsync(serviceRecordMetadata.DocumentId, serviceRecordResponse);
			else
				cachedServiceRecord = await Halo5DdbRepository.CreateAsync(serviceRecordResponse);

			// Create DocumentDb and Database entry
			var serviceRecord = _serviceRecordRepository.Where(sr => sr.Xuid == playerXuid).FirstOrDefault();
			if (serviceRecord == null)
				_serviceRecordRepository.Add(new Database.Models.ServiceRecord
				{
					DocumentId = cachedServiceRecord.Id,
					Xuid = (Int64) cachedServiceRecord.Results.First().Result.PlayerId.Xuid,
				});
			else
			{
				serviceRecord.DocumentId = cachedServiceRecord.Id;
				_serviceRecordRepository.Update(serviceRecord);
			}

			// Return Service Record to user
			return cachedServiceRecord;
		}
	}
}
