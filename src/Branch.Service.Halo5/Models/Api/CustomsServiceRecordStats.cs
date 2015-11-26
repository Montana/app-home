using System.Collections.Generic;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class CustomsServiceRecordStats
		: Abstracts.ServiceRecordStats
	{
		[JsonProperty("CustomGameBaseVariantStats")]
		public IReadOnlyCollection<CustomGameBaseVariantStatistics> CustomGameBaseVariantStats { get; set; }

		[JsonProperty("TopGameBaseVariants")]
		public IReadOnlyCollection<GameBaseVariantStatistics> TopGameBaseVariants { get; set; }
	}
}
