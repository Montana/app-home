using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class ArenaServiceRecordStats
		: Abstracts.ServiceRecordStats
	{
		[JsonProperty("ArenaPlaylistStats")]
		public IReadOnlyCollection<ArenaPlaylistStatistics> ArenaPlaylistStats { get; set; }

		[JsonProperty("HighestCsrAttained")]
		public CsrStatistic HighestCsrAttained { get; set; }

		[JsonProperty("ArenaGameBaseVariantStats")]
		public IReadOnlyCollection<ArenaGameBaseVariantStatistics> ArenaGameBaseVariantStats { get; set; }

		[JsonProperty("TopGameBaseVariants")]
		public IReadOnlyCollection<GameBaseVariantStatistics> TopGameBaseVariants { get; set; }

		[JsonProperty("HighestCsrPlaylistId")]
		public Guid HighestCsrPlaylistId { get; set; }
	}
}
