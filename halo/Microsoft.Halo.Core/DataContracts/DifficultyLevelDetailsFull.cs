using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class DifficultyLevelDetailsFull
	{
		[JsonProperty("Id")]
		public uint Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("ImageId")]
		public AssetContainer ImageUrl { get; set; }
	}
}
