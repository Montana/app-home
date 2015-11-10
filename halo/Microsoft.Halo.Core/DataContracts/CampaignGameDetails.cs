using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CampaignGameDetails
		: GameDetails
	{
		[JsonProperty("Mission")]
		public int Mission { get; set; }

		[JsonProperty("CampaignScoringEnabled")]
		public bool CampaignScoringEnabled { get; set; }

		[JsonProperty("CampaignGlobalScore")]
		public int CampaignGlobalScore { get; set; }

		[JsonProperty("SkullIds")]
		public IReadOnlyCollection<int> SkullIds { get; set; }

		[JsonProperty("Difficulty")]
		public Difficulty Difficulty { get; set; }
	}
}
