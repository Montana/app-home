using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class Team
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Score")]
		public int Score { get; set; }

		[JsonProperty("Rank")]
		public int Standing { get; set; }
	}
}
