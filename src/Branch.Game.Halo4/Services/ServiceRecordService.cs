using System.Threading.Tasks;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;
using Branch.Game.Halo4.Database;
using Branch.Game.Halo4.DocumentDb;
using System;
using Microsoft.Halo.Core.DataContracts;
using System.Collections.Generic;
using Branch.Game.Halo4.Database.Repositories.Interfaces;
using System.Linq;

namespace Branch.Game.Halo4.Services
{
	public class ServiceRecordService
		: ServiceBase<ServiceRecordService>
	{
		public ServiceRecordService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, Halo4DbContext halo4DbContext, Halo4DdbRepository halo4DdbRepository, AuthenticationService authenticationService, IServiceRecordRepository serviceRecordRepository)
			: base(loggerFactory, httpManagerService, halo4DbContext, halo4DdbRepository, authenticationService)
		{
			_serviceRecordRepository = serviceRecordRepository;
		}

		private IServiceRecordRepository _serviceRecordRepository;

		private const string GetServiceRecordUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/servicerecord";

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(0, 5, 0);

		public async Task<ServiceRecord> GetServiceRecord(string gamertag)
		{
			return await GetServiceRecord(gamertag, false);
		}

		public async Task<ServiceRecord> GetServiceRecord(string gamertag, bool takeCached)
		{
			// Get Spartan Token Authentication
			var spartanToken = await AuthenticationService.GetSpartanTokenAsync();

			// Check if spartan token is valid
			var validAuthentication = spartanToken != null;

			// Populate template service record url
			var getServiceRecordUri = new Uri(string.Format(GetServiceRecordUrl, gamertag));

			// Get Service Record metadata from Database
			var serviceRecordMetadata = (await _serviceRecordRepository.Where(sr => sr.Gamertag == gamertag)).FirstOrDefault();
			ServiceRecord cachedServiceRecord = null;
			if (serviceRecordMetadata != null)
			{
				// Return data from DocumentDb if we're taking cached version, or it's expired
				if (takeCached || serviceRecordMetadata.UpdatedAt + CacheRefreshTime > DateTime.UtcNow)
				{
					// Get Service Record from DocumentDb
					cachedServiceRecord = Halo4DdbRepository.GetById<ServiceRecord>(serviceRecordMetadata.DocumentId);

					// If the cached Service Record exist, return it
					if (cachedServiceRecord != null)
						return cachedServiceRecord;
				}
			}

			// Get Service Record from 343's Halo Service
			var serviceRecord = await HttpManagerService.ExecuteRequestAsync<ServiceRecord>(HttpMethod.GET, new Uri(string.Format(GetServiceRecordUrl, gamertag)), headers: new Dictionary<string, string>()
			{
				{ "X-343-Authorization-Spartan", spartanToken }
			});
			
			// Check if something went wrong with the request or parsing
			if (serviceRecord == null)
				return null;
			
			// If cached data exists, 
			if (serviceRecordMetadata != null)
				return await Halo4DdbRepository.UpdateAsync<ServiceRecord>(serviceRecordMetadata.DocumentId, serviceRecord);

			cachedServiceRecord = await Halo4DdbRepository.CreateAsync<ServiceRecord>(serviceRecord);
			await _serviceRecordRepository.AddAsync(new Database.Models.ServiceRecord
			{
				DocumentId = cachedServiceRecord.Id,
				Gamertag = cachedServiceRecord.Gamertag,
				ServiceTag = cachedServiceRecord.ServiceTag
			});

			return cachedServiceRecord;
		}
	}
}
