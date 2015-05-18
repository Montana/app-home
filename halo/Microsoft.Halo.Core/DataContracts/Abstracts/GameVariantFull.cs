using System;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	public abstract class GameVariantFull
	{
		[JsonProperty("TotalDuration")]
		public TimeSpan TotalDuration { get; set; }

		public uint TotalGamesStarted { get; set; }

		public uint TotalGamesCompleted { get; set; }

		public uint TotalGamesWon { get; set; }

		public uint TotalMedals { get; set; }

		public uint TotalKills { get; set; }

		public uint TotalDeaths { get; set; }

		public decimal KDRatio { get; set; }
		
		public uint AveragePersonalScore { get; set; }

		public uint Id { get; set; }

		public string Name { get; set; }
	}
}
