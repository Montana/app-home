using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class MedalCountStatistic
	{
		[JsonProperty("MedalId")]
		public long MedalId { get; set; }

		[JsonProperty("Count")]
		public int Count { get; set; }
	}
}
