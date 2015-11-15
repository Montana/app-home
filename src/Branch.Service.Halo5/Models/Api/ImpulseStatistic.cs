using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ImpulseStatistic
	{
		[JsonProperty("Id")]
		public long Id { get; set; }

		[JsonProperty("Count")]
		public int Count { get; set; }
	}
}
