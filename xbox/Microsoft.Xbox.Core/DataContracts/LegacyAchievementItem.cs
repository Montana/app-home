using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class LegacyAchievementItem
		: AchievementItem
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("titleId")]
		public int TitleId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("sequence")]
		public int Sequence { get; set; }

		[JsonProperty("flags")]
		public int Flags { get; set; }

		[JsonProperty("unlockedOnline")]
		public bool UnlockedOnline { get; set; }

		[JsonProperty("unlocked")]
		public bool Unlocked { get; set; }

		[JsonProperty("isSecret")]
		public bool IsSecret { get; set; }

		[JsonProperty("platform")]
		public int Platform { get; set; }

		[JsonProperty("gamerscore")]
		public int Gamerscore { get; set; }

		[JsonProperty("imageId")]
		public int ImageId { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("lockedDescription")]
		public string LockedDescription { get; set; }

		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("isRevoked")]
		public bool IsRevoked { get; set; }

		[JsonProperty("timeUnlocked")]
		public DateTime TimeUnlocked { get; set; }
	}
}
