using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpartanOpsChapterDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Number")]
		public int Number { get; set; }

		[JsonProperty("Title")]
		public string Title { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }
	}
}
