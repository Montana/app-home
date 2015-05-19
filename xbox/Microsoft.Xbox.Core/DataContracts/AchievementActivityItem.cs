using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class AchievementActivityItem
		: ActivityItem
	{
		[JsonProperty("isSecret")]
		public bool IsSecret { get; set; }

		[JsonProperty("hasAppAward")]
		public bool HasAppAward { get; set; }

		[JsonProperty("hasArtAward")]
		public bool HasArtAward { get; set; }

		[JsonProperty("achievementScid")]
		public string AchievementScid { get; set; }

		[JsonProperty("achievementId")]
		public string AchievementId { get; set; }

		[JsonProperty("achievementType")]
		public string AchievementType { get; set; }

		[JsonProperty("achievementIcon")]
		public string AchievementIcon { get; set; }

		[JsonProperty("gamerscore")]
		public int Gamerscore { get; set; }

		[JsonProperty("achievementName")]
		public string AchievementName { get; set; }

		[JsonProperty("achievementDescription")]
		public string AchievementDescription { get; set; }
	}
}
