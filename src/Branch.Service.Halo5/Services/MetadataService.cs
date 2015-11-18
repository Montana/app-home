using System.Threading.Tasks;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;
using Branch.Service.Halo5.Database;
using Branch.Service.Halo5.DocumentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Xuid.Services;
using Branch.Service.Halo5.Models.Api;

namespace Branch.Service.Halo5.Services
{
	public class MetadataService
		: ServiceBase<MetadataService>
	{
		public MetadataService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			XuidLookupService xuidLookupService, Halo5DbContext halo5DbContext, Halo5DdbRepository halo5DdbRepository,
			AuthenticationService authenticationService)
			: base(
				loggerFactory, httpManagerService, xuidLookupService, halo5DbContext, halo5DdbRepository, authenticationService)
		{ }
		
		private const string GetMetadataUrl = "https://www.haloapi.com/metadata/h5/metadata/{0}";
		private const string SpartanRanksMetadataSlug = "spartan-ranks";

		private readonly TimeSpan _cacheRefreshTime = new TimeSpan(0, 30, 0);

		private Response<SpartanRank> SpartanRankMetadata;

		public async Task<Response<SpartanRank>> GetSpartanRanksMetadata()
		{
			// Populate template metadata url
			var getSpartanRanksMetadataUri = new Uri(string.Format(GetMetadataUrl, SpartanRanksMetadataSlug));

			// Get Spartan Ranks Metadata from 343's Halo Service
			var spartanRankMetadataResponse = await HttpManagerService.ExecuteRequestAsync<IReadOnlyCollection<SpartanRank>>(HttpMethod.GET, getSpartanRanksMetadataUri,
				headers: new Dictionary<string, string>
				{
					{ "Ocp-Apim-Subscription-Key", AuthenticationService.GetAuthentication() }
				});

			SpartanRankMetadata = new Response<SpartanRank>
			{
				Results = spartanRankMetadataResponse,
				Count = spartanRankMetadataResponse.Count(),
				ResultCount = spartanRankMetadataResponse.Count(),
				Start = 0
			};

			return SpartanRankMetadata;
		}
	}
}
