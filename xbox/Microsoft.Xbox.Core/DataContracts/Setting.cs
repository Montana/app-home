using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class Setting
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }
	}
}
