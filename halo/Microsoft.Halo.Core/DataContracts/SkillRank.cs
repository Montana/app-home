using System;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SkillRank
	{
		public string PlaylistName { get; set; }

		public string PlaylistDescription { get; set; }

		public AssetContainer PlaylistImageUrl { get; set; }

		public uint PlaylistId { get; set; }

		public uint? CurrentSkillRank { get; set; }
	}
}
