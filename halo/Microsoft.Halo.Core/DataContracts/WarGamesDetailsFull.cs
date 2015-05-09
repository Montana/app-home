using Microsoft.Halo.Core.DataContracts.Abstracts;

namespace Microsoft.Halo.Core.DataContracts
{
	public class WarGamesDetailsFull
		: GameModeDetailsFull
	{
		public uint TotalGamesCompleted { get; set; }

		public uint TotalGamesWon { get; set; }

		public uint TotalMedals { get; set; }

		public uint AveragePersonalScore { get; set; }

		public decimal KDRatio { get; set; }

		public uint TotalGameBaseVariantMedals { get; set; }

		public GameBaseVariantFull FavouriteVariant { get; set; }
	}
}
