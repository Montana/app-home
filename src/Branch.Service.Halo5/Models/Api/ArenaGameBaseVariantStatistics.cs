using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ArenaGameBaseVariantStatistics
		: Abstracts.ServiceRecordStats
	{
		[JsonProperty("FlexibleStats")]
		public FlexibleStatistics FlexibleStats { get; set; }

		[JsonProperty("GameBaseVariantId")]
		public string GameBaseVariantId { get; set; }
	}
}
