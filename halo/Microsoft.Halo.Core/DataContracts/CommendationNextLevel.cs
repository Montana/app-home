using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CommendationNextLevel
	{
		[JsonProperty("NextLevelName")]
		public string NextLevelName { get; set; }

		[JsonProperty("ProgressToNextLevel")]
		public double ProgressToNextLevel { get; set; }

		[JsonProperty("NextLevelStartTicks")]
		public uint NextLevelStartTicks { get; set; }
	}
}
