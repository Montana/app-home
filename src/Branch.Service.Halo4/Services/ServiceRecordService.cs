﻿using System.Threading.Tasks;
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
using Branch.Helpers.Exceptions;

namespace Branch.Service.Halo4.Services
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

		public async Task<ServiceRecordDetailsFull> GetServiceRecord(string gamertag)
		{
			return await GetServiceRecord(gamertag, false);
		}

		public async Task<ServiceRecordDetailsFull> GetServiceRecord(string gamertag, bool takeCached)
		{
			// Populate template service record url
			var getServiceRecordUri = new Uri(string.Format(GetServiceRecordUrl, gamertag));

			// Get Service Record metadata from Database
			var serviceRecordMetadata = _serviceRecordRepository.Where(sr => sr.Gamertag == gamertag).FirstOrDefault();
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

			// Get Service Record from 343's Halo Service
			var serviceRecord = await HttpManagerService.ExecuteRequestAsync<ServiceRecordDetailsFull>(HttpMethod.GET, getServiceRecordUri);

			// Check if something went wrong with the request or parsing
			if (serviceRecord == null)
				return null; // TODO: find a way to acess this data and throw the relevant exception

			// Check response
			switch (serviceRecord.StatusCode)
			{
				case StatusCode.NoData:
					throw new PlayerHasntPlayedHalo4Exception();

				case StatusCode.PlayerDoesntExist:
					throw new PlayerDoesntExistException();
			}

			// Update documentdb and return data if it exists in the DocumentDb
			if (serviceRecordMetadata != null)
				return await Halo4DdbRepository.UpdateAsync<ServiceRecordDetailsFull>(serviceRecordMetadata.DocumentId, serviceRecord);

			// Create DocumentDb and Database entry
			cachedServiceRecord = await Halo4DdbRepository.CreateAsync<ServiceRecordDetailsFull>(serviceRecord);
			_serviceRecordRepository.Add(new Database.Models.ServiceRecord
			{
				DocumentId = cachedServiceRecord.Id,
				Gamertag = cachedServiceRecord.Gamertag,
				ServiceTag = cachedServiceRecord.ServiceTag
			});

			// Return Service Record to user
			return cachedServiceRecord;
		}
	}
}
