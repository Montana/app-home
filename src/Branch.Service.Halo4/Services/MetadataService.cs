using Branch.Helpers.Services;
using Branch.Service.Halo4.Database;
using Branch.Service.Halo4.Database.Repositories.Interfaces;
using Branch.Service.Halo4.DocumentDb;
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

		private const string GetMetadataUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/servicerecord";

		private IMetadataRepository _metadataRepository;

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(12, 0, 0);

		public static Metadata CachedMetadata = null;

		public async Task<Metadata> GetMetadataAsync()
		{
			if (CachedMetadata != null)
				return CachedMetadata;

			var metadataResponse =
				await HttpManagerService.ExecuteRequestAsync<Metadata>(HttpMethod.GET, new Uri(GetMetadataUrl));

			CachedMetadata = metadataResponse;

			return CachedMetadata;
		}
	}
}
