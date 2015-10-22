using Branch.Helpers.Services;
using Branch.Service.Halo4.Database;
using Branch.Service.Halo4.Database.Repositories.Interfaces;
using Branch.Service.Halo4.DocumentDb;
using Branch.Service.Halo4.Models.Settings;
using Branch.Service.Xuid.Services;
using Microsoft.Framework.Logging;
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

		private IMetadataRepository _metadataRepository;

		private static Metadata _cachedMetadata = null;

		private static WebAppSettings _cachedWebAppSettings = null;

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(12, 0, 0);

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

		public async Task<string> ResolveSpartanImage(ServiceRecordDetailsFull serviceRecord, string pose, string size)
		{
			var webappSettings = await GetWebAppSettingsAsync();

			return string.Format(GetSpartanImageUrl, serviceRecord.Gamertag, pose, size);
		}
	}
}
