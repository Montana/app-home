using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpartanOpsEpisodeDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Title")]
		public string Title { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("Videos")]
		public IReadOnlyCollection<SpartanOpsVideoDetailsFull> Videos { get; set; }

		[JsonProperty("Chapters")]
		public IReadOnlyCollection<SpartanOpsChapterDetailsFull> Chapters { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }
	}
}
