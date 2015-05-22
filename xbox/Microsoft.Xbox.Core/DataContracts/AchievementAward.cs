using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class AchievementAward
	{
		[JsonProperty("name")]
		public object Name { get; set; }

		[JsonProperty("description")]
		public object Description { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("mediaAsset")]
		public object MediaAsset { get; set; }

		[JsonProperty("valueType")]
		public string ValueType { get; set; }
	}
}
