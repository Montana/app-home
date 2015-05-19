using System;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	public abstract class GameVariantFull
	{
		[JsonProperty("TotalDuration")]
		public TimeSpan TotalDuration { get; set; }

		[JsonProperty("TotalGamesStarted")]
		public uint TotalGamesStarted { get; set; }

		[JsonProperty("TotalGamesCompleted")]
		public uint TotalGamesCompleted { get; set; }

		[JsonProperty("TotalGamesWon")]
		public uint TotalGamesWon { get; set; }

		[JsonProperty("TotalMedals")]
		public uint TotalMedals { get; set; }

		[JsonProperty("TotalKills")]
		public uint TotalKills { get; set; }

		[JsonProperty("TotalDeaths")]
		public uint TotalDeaths { get; set; }

		[JsonProperty("KDRatio")]
		public decimal KDRatio { get; set; }

		[JsonProperty("AveragePersonalScore")]
		public uint AveragePersonalScore { get; set; }

		[JsonProperty("Id")]
		public uint Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
