using Branch.Service.Halo5.Models.Api.Enums;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class Player
	{
		[JsonProperty("Player")]
		public PlayerId PlayerId { get; set; }

		[JsonProperty("TeamId")]
		public int TeamId { get; set; }

		[JsonProperty("Rank")]
		public int Standing { get; set; }

		[JsonProperty("Result")]
		public MatchResult Result { get; set; }

		[JsonProperty("TotalKills")]
		public int TotalKills { get; set; }

		[JsonProperty("TotalDeaths")]
		public int TotalDeaths { get; set; }

		[JsonProperty("TotalAssists")]
		public int TotalAssists { get; set; }

		[JsonProperty("PreMatchRatings")]
		public object PreMatchRatings { get; set; }

		[JsonProperty("PostMatchRatings")]
		public object PostMatchRatings { get; set; }
	}
}
