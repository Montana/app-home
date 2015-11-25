using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ArenaPlaylistStatistics
		: Abstracts.ServiceRecordStats
	{
		[JsonProperty("PlaylistId")]
		public string PlaylistId { get; set; }

		[JsonProperty("MeasurementMatchesLeft")]
		public int MeasurementMatchesLeft { get; set; }

		[JsonProperty("HighestCsr")]
		public CsrStatistic HighestCsr { get; set; }

		[JsonProperty("Csr")]
		public CsrStatistic Csr { get; set; }
	}
}
