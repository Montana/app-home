using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class PreferredColor
	{
		[JsonProperty("primaryColor")]
		public string PrimaryColor { get; set; }

		[JsonProperty("secondaryColor")]
		public string SecondaryColor { get; set; }

		[JsonProperty("tertiaryColor")]
		public string TertiaryColor { get; set; }
	}
}
