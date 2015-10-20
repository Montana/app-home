using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class MapMetadata
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("GameModeId")]
		public GameMode GameModeId { get; set; }

		[JsonProperty("ArticleId")]
		public string ArticleId { get; set; }

		[JsonProperty("Order")]
		public int Order { get; set; }

		[JsonProperty("Mission")]
		public int Mission { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }
	}
}
