using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class MapVariant
	{
		[JsonProperty("BaseMapId")]
		public int BaseMapId { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
