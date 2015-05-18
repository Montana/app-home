using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class WarGamesDetailsFull
		: GameModeDetailsFull
	{
		[JsonProperty("TotalGamesCompleted")]
		public uint TotalGamesCompleted { get; set; }

		[JsonProperty("TotalGamesWon")]
		public uint TotalGamesWon { get; set; }

		[JsonProperty("TotalMedals")]
		public uint TotalMedals { get; set; }

		[JsonProperty("AveragePersonalScore")]
		public uint AveragePersonalScore { get; set; }

		[JsonProperty("KDRatio")]
		public decimal KDRatio { get; set; }

		[JsonProperty("TotalGameBaseVariantMedals")]
		public uint TotalGameBaseVariantMedals { get; set; }

		[JsonProperty("FavouriteVariant")]
		public GameBaseVariantFull FavouriteVariant { get; set; }
	}
}
