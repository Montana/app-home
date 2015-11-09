using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class GameBaseVariantDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("KDRelevant")]
		public bool KillDeathRatioRelevant { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("FeaturedStatName")]
		public string FeaturedStatName { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }
	}
}
