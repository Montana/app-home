using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ScenarioStatistic
		: Abstracts.ServiceRecordStats
	{
		[JsonProperty("TotalPiesEarned")]
		public int TotalPiesEarned { get; set; }

		[JsonProperty("FlexibleStats")]
		public FlexibleStatistics FlexibleStats { get; set; }

		[JsonProperty("MapId")]
		public string MapId { get; set; }

		[JsonProperty("GameBaseVariantId")]
		public string GameBaseVariantId { get; set; }
	}
}
