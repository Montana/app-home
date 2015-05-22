using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class DurangoUserTitle
		: UserTitle
	{
		[JsonProperty("lastUnlock")]
		public DateTime LastUnlock { get; set; }

		[JsonProperty("serviceConfigId")]
		public string ServiceConfigurationId { get; set; }

		[JsonProperty("titleType")]
		public string TitleType { get; set; }

		[JsonProperty("platform")]
		public string Platform { get; set; }

		[JsonProperty("earnedAchievements")]
		public uint EarnedAchievements { get; set; }
		
		[JsonProperty("maxGamerscore")]
		public uint MaxGamerscore { get; set; }
	}
}
