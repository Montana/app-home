﻿using Branch.Helpers.Services;
using Branch.Service.Halo4.Database;
using Branch.Service.Halo4.Database.Repositories.Interfaces;
using Branch.Service.Halo4.DocumentDb;
using Branch.Service.Halo4.Models.Settings;
using Branch.Service.Xuid.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Halo.Core.DataContracts;
using System;
using System.Threading.Tasks;

namespace Branch.Service.Halo4.Services
{
	public class MetadataService
		: ServiceBase<MetadataService>
	{
		public MetadataService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			XuidLookupService xuidLookupService, Halo4DbContext halo4DbContext,
			Halo4DdbRepository halo4DdbRepository, IMetadataRepository metadataRepository,
			AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{
			_metadataRepository = metadataRepository;
		}

		private const string GetMetadataUrl = "https://stats.svc.halowaypoint.com/en-US/h4/metadata";

		private const string GetWebAppSettingsUrl = "https://settings.svc.halowaypoint.com/RegisterClientService.svc/register/webapp/AE5D20DCFA0347B1BCE0A5253D116752?_=1445517265985";

		private const string GetSpartanImageUrl = "https://spartans.svc.halowaypoint.com/players/{0}/h4/spartans/{1}?target={2}";

		private const string GetCsrImageUrl = "https://assets.halowaypoint.com/games/h4/csr/v1/{0}/{1}.png";

		private IMetadataRepository _metadataRepository;

		private static Metadata _cachedMetadata = null;

		private static WebAppSettings _cachedWebAppSettings = null;
		
		public async Task<WebAppSettings> GetWebAppSettingsAsync()
		{
			if (_cachedWebAppSettings != null)
				return _cachedWebAppSettings;

			var webAppSettingsResponse =
				await HttpManagerService.ExecuteRequestAsync<WebAppSettings>(HttpMethod.GET, new Uri(GetWebAppSettingsUrl));

			_cachedWebAppSettings = webAppSettingsResponse;

			return _cachedWebAppSettings;
		}

		public async Task<Metadata> GetMetadataAsync()
		{
			if (_cachedMetadata != null)
				return _cachedMetadata;

			var metadataResponse =
				await HttpManagerService.ExecuteRequestAsync<Metadata>(HttpMethod.GET, new Uri(GetMetadataUrl));

			_cachedMetadata = metadataResponse;

			return _cachedMetadata;
		}
		
		public async Task<string> ResolveAssetContainerAsync(AssetContainer assetContainer, string size = "")
		{
			var webAppSettings = await GetWebAppSettingsAsync();

			switch (assetContainer.BaseUrl)
			{
				case "H4MapAssets":
					return $"/images/areas/halo4/maps{assetContainer.AssetUrl.Replace("{size}", "").Replace(".png", ".jpg")}";

				default:
					return $"{webAppSettings.Settings[assetContainer.BaseUrl]}{assetContainer.AssetUrl.Replace("{size}", size)}";
			}
		}

		public string ResolveSpartanImage(ServiceRecordDetailsFull serviceRecord, string pose = "fullbody", string size = "large")
		{
			return ResolveSpartanImage(serviceRecord.Gamertag, pose, size);
		}

		public string ResolveSpartanImage(string gamertag, string pose = "fullbody", string size = "large")
		{
			return string.Format(GetSpartanImageUrl, gamertag, pose, size);
		}

		public string ResolveCsrImage(SkillRankDetailsFull skillRank, string size)
		{
			return string.Format(GetCsrImageUrl, size, skillRank?.CurrentSkillRank ?? 0);
		}
	}
}
