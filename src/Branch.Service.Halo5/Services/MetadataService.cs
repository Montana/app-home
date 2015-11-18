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
using Branch.Service.Halo5.Database.Repositories.Interfaces;

namespace Branch.Service.Halo5.Services
{
	public class MetadataService
		: ServiceBase<MetadataService>
	{
		public MetadataService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			XuidLookupService xuidLookupService, Halo5DbContext halo5DbContext, Halo5DdbRepository halo5DdbRepository,
			AuthenticationService authenticationService, IMapVariantRepository mapVariantRepository, IGameVariantRepository gameVariantRepository)
			: base(
				loggerFactory, httpManagerService, xuidLookupService, halo5DbContext, halo5DdbRepository, authenticationService)
		{
			_mapVariantRepository = mapVariantRepository;
			_gameVariantRepository = gameVariantRepository;
		}

		private readonly IMapVariantRepository _mapVariantRepository;
		private readonly IGameVariantRepository _gameVariantRepository;

		private const string GetMetadataUrl = "https://www.haloapi.com/metadata/h5/metadata/{0}";
		private const string GetMetadataExtendedUrl = "https://www.haloapi.com/metadata/h5/metadata/{0}/{1}";
		private const string SpartanRanksMetadataSlug = "spartan-ranks";
		private const string MapsMetadataSlug = "maps";
		private const string MapVariantMetadataSlug = "map-variants";
		private const string GameBaseVariantsMetadataSlug = "game-base-variants";
		private const string GameVariantMetadataSlug = "game-variants";

		private readonly TimeSpan _cacheRefreshTime = new TimeSpan(0, 30, 0);
		private readonly TimeSpan _localCacheRefreshTime = TimeSpan.FromDays(100);

		private Response<SpartanRank> SpartanRankMetadata;
		private Response<Map> MapMetadata;
		private Response<GameBaseVariant> GameBaseVariantMetadata;

		public async Task<Response<SpartanRank>> GetSpartanRanksMetadataAsync()
		{
			if (SpartanRankMetadata != null)
				return SpartanRankMetadata;

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

		public async Task<Response<Map>> GetMapsMetadataAsync()
		{
			if (MapMetadata != null)
				return MapMetadata;

			// Populate template metadata url
			var getMapsMetadataUri = new Uri(string.Format(GetMetadataUrl, MapsMetadataSlug));

			// Get Maps Metadata from 343's Halo Service
			var mapMetadataResponse = await HttpManagerService.ExecuteRequestAsync<IReadOnlyCollection<Map>>(HttpMethod.GET, getMapsMetadataUri,
				headers: new Dictionary<string, string>
				{
					{ "Ocp-Apim-Subscription-Key", AuthenticationService.GetAuthentication() }
				});

			MapMetadata = new Response<Map>
			{
				Results = mapMetadataResponse,
				Count = mapMetadataResponse.Count(),
				ResultCount = mapMetadataResponse.Count(),
				Start = 0
			};

			return MapMetadata;
		}

		public async Task<MapVariant> GetMapVariantMetadataAsync(Guid mapVariantId)
		{
			var mapVariant = _mapVariantRepository.Where(mv => mv.MapVariantId == mapVariantId).FirstOrDefault();
			if (mapVariant != null && mapVariant.UpdatedAt + _localCacheRefreshTime > DateTime.UtcNow)
				return new MapVariant
				{
					Id = mapVariant.MapVariantId,
					ContentId = mapVariant.ContentId,
					Description = mapVariant.Description,
					MapId = mapVariant.MapId,
					MapImageUrl = mapVariant.MapImageUrl,
					Name = mapVariant.Name
				};

			// Populate template metadata url
			var getMapVariantMetadataUri = new Uri(string.Format(GetMetadataExtendedUrl, MapVariantMetadataSlug, mapVariantId));

			// Get Map Variant Metadata from 343's Halo Service
			var mapVariantMetadataResponse = await HttpManagerService.ExecuteRequestAsync<MapVariant>(HttpMethod.GET, getMapVariantMetadataUri,
				headers: new Dictionary<string, string>
				{
					{ "Ocp-Apim-Subscription-Key", AuthenticationService.GetAuthentication() }
				});

			if (mapVariant == null)
				mapVariant = new Database.Models.MapVariant();

			mapVariant.ContentId = mapVariantMetadataResponse.ContentId;
			mapVariant.Description = mapVariantMetadataResponse.Description;
			mapVariant.MapId = mapVariantMetadataResponse.MapId;
			mapVariant.MapImageUrl = mapVariantMetadataResponse.MapImageUrl;
			mapVariant.MapVariantId = mapVariantMetadataResponse.Id;
			mapVariant.Name = mapVariantMetadataResponse.Name;
			_mapVariantRepository.Update(mapVariant);

			return mapVariantMetadataResponse;
        }

		public async Task<Response<GameBaseVariant>> GetGameBaseVariantsMetadataAsync()
		{
			if (GameBaseVariantMetadata != null)
				return GameBaseVariantMetadata;

			// Populate template metadata url
			var getGameBaseVariantMetadataUri = new Uri(string.Format(GetMetadataUrl, GameBaseVariantsMetadataSlug));

			// Get Game Base Variant Metadata from 343's Halo Service
			var gameBaseVariantMetadataResponse = await HttpManagerService.ExecuteRequestAsync<IReadOnlyCollection<GameBaseVariant>>(HttpMethod.GET, getGameBaseVariantMetadataUri,
				headers: new Dictionary<string, string>
				{
					{ "Ocp-Apim-Subscription-Key", AuthenticationService.GetAuthentication() }
				});

			GameBaseVariantMetadata = new Response<GameBaseVariant>
			{
				Results = gameBaseVariantMetadataResponse,
				Count = gameBaseVariantMetadataResponse.Count(),
				ResultCount = gameBaseVariantMetadataResponse.Count(),
				Start = 0
			};

			return GameBaseVariantMetadata;
		}

		public async Task<GameVariant> GetGameVariantMetadataAsync(Guid gameVariantId)
		{
			var gameVariant = _gameVariantRepository.Where(gv => gv.GameVariantId == gameVariantId).FirstOrDefault();
			if (gameVariant != null && gameVariant.UpdatedAt + _localCacheRefreshTime > DateTime.UtcNow)
				return new GameVariant
				{
					Id = gameVariant.GameVariantId,
					ContentId = gameVariant.ContentId,
					Description = gameVariant.Description,
					GameBaseVariantId = gameVariant.GameBaseVariantId,
					IconUrl = gameVariant.IconUrl,
					Name = gameVariant.Name
				};

			// Populate template metadata url
			var getGameVariantMetadataUri = new Uri(string.Format(GetMetadataExtendedUrl, GameVariantMetadataSlug, gameVariantId));

			// Get Game Variant Metadata from 343's Halo Service
			var gameVariantMetadataResponse = await HttpManagerService.ExecuteRequestAsync<GameVariant>(HttpMethod.GET, getGameVariantMetadataUri,
				headers: new Dictionary<string, string>
				{
					{ "Ocp-Apim-Subscription-Key", AuthenticationService.GetAuthentication() }
				});

			if (gameVariant == null)
				gameVariant = new Database.Models.GameVariant();

			gameVariant.ContentId = gameVariantMetadataResponse.ContentId;
			gameVariant.Description = gameVariantMetadataResponse.Description;
			gameVariant.GameBaseVariantId = gameVariantMetadataResponse.GameBaseVariantId;
			gameVariant.IconUrl = gameVariantMetadataResponse.IconUrl;
			gameVariant.GameVariantId = gameVariantMetadataResponse.Id;
			gameVariant.Name = gameVariantMetadataResponse.Name;
			_gameVariantRepository.Update(gameVariant);

			return gameVariantMetadataResponse;
		}
	}
}
