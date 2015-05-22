using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class MediaGenre
	{
		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
