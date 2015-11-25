using Newtonsoft.Json;
using System.Collections.Generic;

namespace Branch.Service.Halo5.Models.Api
{
	public class CampaignMissionCompletionStatistics
	{
		[JsonProperty("HighestScore")]
		public int HighestScore { get; set; }

		[JsonProperty("FastestCompletionTime")]
		public string FastestCompletionTime { get; set; }

		[JsonProperty("Skulls")]
		public IReadOnlyCollection<int> Skulls { get; set; }

		[JsonProperty("TotalTimesCompleted")]
		public int TotalTimesCompleted { get; set; }

		[JsonProperty("AllSkullsOn")]
		public bool AllSkullsOn { get; set; }
	}
}
