using System.Threading.Tasks;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;
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

namespace Branch.Service.Halo4.Services
{
	public class ServiceRecordService
		: ServiceBase<ServiceRecordService>
	{
		public ServiceRecordService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, Halo4DbContext halo4DbContext, Halo4DdbRepository halo4DdbRepository, AuthenticationService authenticationService, IServiceRecordRepository serviceRecordRepository)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{
			_serviceRecordRepository = serviceRecordRepository;
		}

		private IServiceRecordRepository _serviceRecordRepository;

		private const string GetServiceRecordUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/servicerecord";

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(0, 5, 0);

		public async Task<ServiceRecordDetailsFull> GetServiceRecord(string gamertag)
		{
			return await GetServiceRecord(gamertag, false);
		}

		public async Task<ServiceRecordDetailsFull> GetServiceRecord(string gamertag, bool takeCached)
		{
			// Get Player XUID
			var playerXuid = await XuidLookupService.LookupXuidAsync(gamertag);

			// Get Service Record metadata from Database
			var serviceRecordMetadata = _serviceRecordRepository.Where(sr => sr.Xuid == playerXuid).FirstOrDefault();
			ServiceRecordDetailsFull cachedServiceRecord = null;
			if (serviceRecordMetadata != null)
			{
				// Return data from DocumentDb if we're taking cached version, or it's expired
				if (takeCached || serviceRecordMetadata.UpdatedAt + CacheRefreshTime > DateTime.UtcNow)
				{
					// Get Service Record from DocumentDb
					cachedServiceRecord = Halo4DdbRepository.GetById<ServiceRecordDetailsFull>(serviceRecordMetadata.DocumentId);

					// If the cached Service Record exist, return it
					if (cachedServiceRecord != null)
						return cachedServiceRecord;
				}
			}

			// Populate template service record url
			var getServiceRecordUri = new Uri(string.Format(GetServiceRecordUrl, gamertag));

			// Get Service Record from 343's Halo Service
			var serviceRecordResponse = await HttpManagerService.ExecuteRequestAsync<ServiceRecordDetailsFull>(HttpMethod.GET, getServiceRecordUri);

			// Check if something went wrong with the request or parsing
			if (serviceRecordResponse == null)
				return null; // TODO: find a way to access this data and throw the relevant exception

			// Check response
			switch (serviceRecordResponse.StatusCode)
			{
				case StatusCode.NoData:
					throw new PlayerHasntPlayedHalo4Exception();

				case StatusCode.PlayerDoesntExist:
					throw new PlayerDoesntExistException();
			}

			// Set the XUID in the service record
			serviceRecordResponse.Xuid = playerXuid;

			// Update documentdb and return data if it exists in the DocumentDb
			if (serviceRecordMetadata != null)
				cachedServiceRecord = await Halo4DdbRepository.UpdateAsync(serviceRecordMetadata.DocumentId, serviceRecordResponse);
			else
				cachedServiceRecord = await Halo4DdbRepository.CreateAsync(serviceRecordResponse);

			// Create DocumentDb and Database entry
			var serviceRecord = _serviceRecordRepository.Where(sr => sr.Xuid == playerXuid).FirstOrDefault();
			if (serviceRecord == null)
				_serviceRecordRepository.Add(new Database.Models.ServiceRecord
				{
					DocumentId = cachedServiceRecord.Id,
					Xuid = cachedServiceRecord.Xuid,
					ServiceTag = cachedServiceRecord.ServiceTag
				});
			else
			{
				serviceRecord.DocumentId = cachedServiceRecord.Id;
				serviceRecord.ServiceTag = cachedServiceRecord.ServiceTag;
				_serviceRecordRepository.Update(serviceRecord);
			}

			// Return Service Record to user
			return cachedServiceRecord;
		}
	}
}
