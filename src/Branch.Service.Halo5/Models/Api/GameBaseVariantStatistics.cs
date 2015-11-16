﻿using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class GameBaseVariantStatistics
	{
		[JsonProperty("GameBaseVariantRank")]
		public int GameBaseVariantRank { get; set; }

		[JsonProperty("NumberOfMatchesCompleted")]
		public int NumberOfMatchesCompleted { get; set; }

		[JsonProperty("GameBaseVariantId")]
		public string GameBaseVariantId { get; set; }

		[JsonProperty("NumberOfMatchesWon")]
		public int NumberOfMatchesWon { get; set; }
	}
}