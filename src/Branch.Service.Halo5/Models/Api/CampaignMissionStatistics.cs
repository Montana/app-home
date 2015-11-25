using Branch.Service.Halo5.Models.Api.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Branch.Service.Halo5.Models.Api
{
	public class CampaignMissionStatistics
		: Abstracts.ServiceRecordStats
	{
		[JsonProperty("FlexibleStats")]
		public FlexibleStatistics FlexibleStats { get; set; }

		[JsonProperty("CoopStats")]
		public Dictionary<Difficulty, CampaignMissionCompletionStatistics> CoopStats { get; set; }

		[JsonProperty("SoloStats")]
		public Dictionary<Difficulty, CampaignMissionCompletionStatistics> SoloStats { get; set; }

		[JsonProperty("MissionId")]
		public string MissionId { get; set; }
	}
}
