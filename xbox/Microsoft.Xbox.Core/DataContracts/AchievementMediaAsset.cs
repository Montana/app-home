using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class AchievementMediaAsset
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
