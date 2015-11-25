using System.Collections.Generic;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class WarzoneServiceRecordStats
		: Abstracts.ServiceRecordStats
	{
		[JsonProperty("TotalPiesEarned")]
		public int TotalPiesEarned { get; set; }

		[JsonProperty("ScenarioStats")]
		public IReadOnlyCollection<ScenarioStatistic> ScenarioStats { get; set; }
	}
}
