using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class MediaAvailabilityDevice
	{
		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
