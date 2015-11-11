using Branch.Helpers.Extentions;
using Branch.Service.Halo4.Services;
using Microsoft.Halo.Core.DataContracts;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Branch.Web.Areas.Halo4.Extentions
{
	public static class GameHistoryExtentions
	{
		public static async Task<string> ToJavascriptArrayAsync(this IReadOnlyCollection<GameHistory> gameHistory, MetadataService metadataService, string gamertag)
		{
			var javascriptObjectArray = new List<object>();

			foreach (WarGameHistory game in gameHistory)
			{
				var result = "Did Not Finish";
				var resultClass = "dnf";
				switch (game.Result)
				{
					case GameResult.Won:
						result = "Victory";
						resultClass = "victory";
						break;

					case GameResult.Lost:
						result = "Defeat";
						resultClass = "defeat";
						break;

					case GameResult.Draw:
						result = "Tie";
						resultClass = "dnf";
						break;
				}

				var mapMetadata = (await metadataService.GetMetadataAsync()).MapsMetadata.Maps.First(m => m.Id == game.MapId);

				javascriptObjectArray.Add(new
				{
					Id = game.Id,
					Result = result,
					ResultClass = resultClass,
					GameMode = game.VariantName,
					GameModeSlug = game.Mode.GetDescription().ToSlug(),
					Gamertag = gamertag,
					FeaturedStatValue = game.FeaturedStatValue,
					FeaturedStatName = game.FeaturedStatName,
					Map = game.MapVariantName,
					BaseMapName = mapMetadata.Name,
					BaseMapImageUrl = (await metadataService.ResolveAssetContainerAsync(mapMetadata.ImageUrl)),
					EndDate = game.EndDateUtc.ToString("dddd, MMMM dd yyyy")
				});
			}

			return JsonConvert.SerializeObject(javascriptObjectArray);
		}
	}
}
