using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class AchievementProgression
	{
		[JsonProperty("requirements")]
		public IReadOnlyCollection<AchievementProgressionRequirement> Requirements { get; set; }

		[JsonProperty("timeUnlocked")]
		public DateTime TimeUnlocked { get; set; }
	}
}
