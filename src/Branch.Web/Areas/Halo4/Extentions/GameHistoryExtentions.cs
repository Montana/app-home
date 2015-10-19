using Microsoft.Halo.Core.DataContracts;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Branch.Web.Areas.Halo4.Extentions
{
	public static class GameHistoryExtentions
	{
		public static string ToJavascriptArray(this IReadOnlyCollection<GameHistory> gameHistory)
		{
			var sb = new StringBuilder();

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

				var model = new
				{
					result = result,
					resultClass = resultClass,
					gameMode = game.PlaylistName,
					featuredStatValue = game.FeaturedStatValue,
					featuredStatName = game.FeaturedStatName,
					map = game.MapVariantName,
					baseMapName = "complex", // TODO: this
					endDate = game.EndDateUtc.ToString("dddd, MMMM dd yyyy")
				};

				sb.Append(JsonConvert.SerializeObject(model));
				sb.Append(",");
			}

			return sb.ToString();
		}
	}
}
