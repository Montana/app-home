using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpecializationDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("MaxSpecializationXP")]
		public int MaxSpecializationXP { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }
	}
}
