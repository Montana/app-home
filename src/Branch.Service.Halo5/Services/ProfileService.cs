using System.Threading.Tasks;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;
using Branch.Service.Halo5.Database;
using Branch.Service.Halo5.DocumentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Branch.Service.Halo5.Database.Enums;
using Branch.Service.Halo5.Database.Models;
using Branch.Service.Halo5.Database.Repositories.Interfaces;
using Branch.Service.Halo5.Models.Api;
using Branch.Service.Xuid.Exceptions;
using Branch.Service.Xuid.Services;

namespace Branch.Service.Halo5.Services
{
	public class ProfileService
		: ServiceBase<ProfileService>
	{
		public ProfileService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			XuidLookupService xuidLookupService, Halo5DbContext halo5DbContext, Halo5DdbRepository halo5DdbRepository,
			AuthenticationService authenticationService, IProfileAssetRepository profileAssetRepository)
			: base(
				loggerFactory, httpManagerService, xuidLookupService, halo5DbContext, halo5DdbRepository, authenticationService)
		{
			_profileAssetRepository = profileAssetRepository;
		}

		private IProfileAssetRepository _profileAssetRepository;

		private const string GetEmblemUrl = "https://www.haloapi.com/profile/h5/profiles/{0}/emblem?size={1}";

		private readonly TimeSpan _cacheRefreshTime = new TimeSpan(0, 5, 0);

		public async Task<string> GetProfileEmblemAsync(string gamertag, int size = 128)
		{
			return await GetProfileEmblemAsync(gamertag, false, size);
		}

		public async Task<string> GetProfileEmblemAsync(string gamertag, bool takeCached, int size = 128)
		{
			// Get Player XUID
			var playerXuid = await XuidLookupService.LookupXuidAsync(gamertag);
			
			// Get Emblem metadata from repository
			var emblemMetadata = _profileAssetRepository.Where(pa => pa.Xuid == playerXuid && pa.Type == ProfileAssetType.Emblem).FirstOrDefault();
			if (emblemMetadata != null && (emblemMetadata.UpdatedAt + _cacheRefreshTime > DateTime.UtcNow))
			{
				return emblemMetadata.ImagePath;
			}

			// Populate template emblem url
			var getEmblemUri = new Uri(string.Format(GetEmblemUrl, gamertag, size));

			// Get Emblem from 343's Halo Service
			var emblemResponse = await HttpManagerService.ExecuteRequestAsync(HttpMethod.GET, getEmblemUri,
				headers: new Dictionary<string, string>
				{
					{ "Ocp-Apim-Subscription-Key", AuthenticationService.GetAuthentication() }
				});

			switch (emblemResponse.StatusCode)
			{
				case HttpStatusCode.NotFound:
					throw new PlayerDoesntExistException();
				case HttpStatusCode.BadRequest:
					throw new ArgumentOutOfRangeException(nameof(size));
			}

			var profileAsset = _profileAssetRepository.Where(sr => sr.Xuid == playerXuid && sr.Type == ProfileAssetType.Emblem).FirstOrDefault();
			if (profileAsset == null)
				_profileAssetRepository.Add(new ProfileAsset
				{
					ImagePath = emblemResponse.RequestMessage.RequestUri.ToString(),
					Type = ProfileAssetType.Emblem,
					Xuid = playerXuid,
				});
			else
			{
				profileAsset.ImagePath = emblemResponse.RequestMessage.RequestUri.ToString();
				_profileAssetRepository.Update(profileAsset);
			}

			return emblemResponse.RequestMessage.RequestUri.ToString();
		}
	}
}
