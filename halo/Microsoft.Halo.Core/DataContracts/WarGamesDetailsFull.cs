using System.Runtime.Serialization;
using Microsoft.Halo.Core.DataContracts.Abstracts;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class WarGamesDetailsFull
		: GameModeDetailsFull
	{
		[DataMember(Name = "TotalGamesCompleted")]
		public uint TotalGamesCompleted { get; set; }

		[DataMember(Name = "TotalGamesWon")]
		public uint TotalGamesWon { get; set; }

		[DataMember(Name = "TotalMedals")]
		public uint TotalMedals { get; set; }

		[DataMember(Name = "AveragePersonalScore")]
		public uint AveragePersonalScore { get; set; }

		[DataMember(Name = "KDRatio")]
		public decimal KDRatio { get; set; }

		[DataMember(Name = "TotalGameBaseVariantMedals")]
		public uint TotalGameBaseVariantMedals { get; set; }

		[DataMember(Name = "FavouriteVariant")]
		public GameBaseVariantFull FavouriteVariant { get; set; }
	}
}
