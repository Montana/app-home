using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class MedalDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("TierId")]
		public MedalTier Tier { get; set; }

		[JsonProperty("ClassId")]
		public MedalClass Class { get; set; }

		[JsonProperty("GameBaseVariantId")]
		public GameBaseVariant GameBaseVariant { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }
	}
}
