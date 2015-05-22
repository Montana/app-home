using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class LegacyUserTitle
		: UserTitle
	{
		[JsonProperty("lastPlayed")]
		public DateTime LastPlayed { get; set; }

		[JsonProperty("currentAchievements")]
		public uint CurrentAchievements { get; set; }

		[JsonProperty("sequence")]
		public uint Sequence { get; set; }

		[JsonProperty("titleType")]
		public uint TitleType { get; set; }

		[JsonProperty("platforms")]
		public Int32[] Platforms { get; set; }

		[JsonProperty("earnedAchievements")]
		public uint EarnedAchievements { get; set; }

		[JsonProperty("totalAchievements")]
		public uint TotalAchievements { get; set; }

		[JsonProperty("totalGamerscore")]
		public uint TotalGamerscore { get; set; }
	}
}
