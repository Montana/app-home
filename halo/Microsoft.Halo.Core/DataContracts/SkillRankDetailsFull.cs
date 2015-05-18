using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SkillRankDetailsFull
	{
		[JsonProperty("PlaylistName")]
		public string PlaylistName { get; set; }

		[JsonProperty("PlaylistDescription")]
		public string PlaylistDescription { get; set; }

		[JsonProperty("PlaylistImageUrl")]
		public AssetContainer PlaylistImageUrl { get; set; }

		[JsonProperty("PlaylistId")]
		public uint PlaylistId { get; set; }

		[JsonProperty("CurrentSkillRank")]
		public uint? CurrentSkillRank { get; set; }
	}
}
