using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class GameVariant
	{
		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("GameBaseVariantId")]
		public int GameBaseVariantId { get; set; }

		[JsonProperty("GameBaseVariantName")]
		public string GameBaseVariantName { get; set; }

		[JsonProperty("GameBaseVariantDescription")]
		public string GameBaseVariantDescription { get; set; }

		[JsonProperty("GameBaseVariantImageUrl")]
		public AssetContainer GameBaseVariantImageUrl { get; set; }
	}
}
