using Branch.Service.Halo5.Models.Api.Abstracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Branch.Service.Halo5.Models.Api
{
	public class MatchHistory
		: Result
	{
		[JsonProperty("Id")]
		public MatchHistoryId Id { get; set; }

		[JsonProperty("HopperId")]
		public Nullable<Guid> HopperId { get; set; }

		[JsonProperty("MapId")]
		public Guid MapId { get; set; }

		[JsonProperty("MapVariant")]
		public MapVariant MapVariant { get; set; }

		[JsonProperty("GameBaseVariantId")]
		public Guid GameBaseVariantId { get; set; }

		[JsonProperty("GameVariant")]
		public GameVariant GameVariant { get; set; }

		[JsonProperty("MatchDuration")]
		public string MatchDuration { get; set; }

		[JsonProperty("MatchCompletedDate")]
		public UniversalDateTimeContainer MatchCompletedDate { get; set; }

		[JsonProperty("Teams")]
		public IReadOnlyCollection<Team> Teams { get; set; }

		[JsonProperty("Players")]
		public IReadOnlyCollection<Player> Players { get; set; }

		[JsonProperty("IsTeamGame")]
		public bool IsTeamGame { get; set; }

		[JsonProperty("SeasonId")]
		public Nullable<Guid> SeasonId { get; set; }
	}
}
