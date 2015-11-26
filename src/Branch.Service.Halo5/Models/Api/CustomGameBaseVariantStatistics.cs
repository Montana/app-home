using System.Collections.Generic;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class CustomGameBaseVariantStatistics
		: Abstracts.ServiceRecordStats
	{
		[JsonProperty("FlexibleStats")]
		public FlexibleStatistics FlexibleStats { get; set; }

		[JsonProperty("GameBaseVariantId")]
		public string GameBaseVariantId { get; set; }
	}
}
