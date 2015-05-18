using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class MedalDetailsFull
	{
		[JsonProperty("Id")]
		public uint Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }

		[JsonProperty("TotalMedals")]
		public uint TotalMedals { get; set; }
	}
}
