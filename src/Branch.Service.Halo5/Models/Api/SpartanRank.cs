using Branch.Service.Halo5.Models.Api.Abstracts;
using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class SpartanRank
		: Result
	{
		[JsonProperty("startXp")]
		public int StartXp { get; set; }

		[JsonProperty("reward")]
		public SpartanRankReward Reward { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("contentId")]
		public Guid ContentId { get; set; }
	}
}
