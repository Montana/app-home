using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class AssetContainer
	{
		[JsonProperty("BaseUrl")]
		public string BaseUrl { get; set; }

		[JsonProperty("AssetUrl")]
		public string AssetUrl { get; set; }
	}
}
