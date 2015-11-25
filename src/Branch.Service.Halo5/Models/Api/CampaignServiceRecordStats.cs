using System.Collections.Generic;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class CampaignServiceRecordStats
		: Abstracts.ServiceRecordStats
	{
		[JsonProperty("CampaignMissionStats")]
		public IReadOnlyCollection<CampaignMissionStatistics> CampaignMissionStats { get; set; }
	}
}
