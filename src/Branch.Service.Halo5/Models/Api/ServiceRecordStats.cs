using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ServiceRecordStats
	{
		[JsonProperty("ArenaStats")]
		public ArenaServiceRecordStats ArenaServiceRecordStats { get; set; }

		[JsonProperty("PlayerId")]
		public PlayerId PlayerId { get; set; }

		[JsonProperty("SpartanRank")]
		public int SpartanRank { get; set; }

		[JsonProperty("Xp")]
		public int Xp { get; set; }
	}
}
