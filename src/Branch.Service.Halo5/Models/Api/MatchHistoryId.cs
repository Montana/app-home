using Branch.Service.Halo5.Models.Api.Enums;
using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class MatchHistoryId
	{
		[JsonProperty("MatchId")]
		public Guid MatchId { get; set; }

		[JsonProperty("GameMode")]
		public GameMode GameMode { get; set; }
	}
}
