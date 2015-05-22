using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class MediaCapability
	{
		[JsonProperty("NonLocalizedName")]
		public string NonLocalizedName { get; set; }

		[JsonProperty("Value")]
		public string Value { get; set; }
	}
}
