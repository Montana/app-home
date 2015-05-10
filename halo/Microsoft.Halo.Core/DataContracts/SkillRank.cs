using System;
using System.Runtime.Serialization;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class SkillRank
	{
		[DataMember(Name = "PlaylistName")]
		public string PlaylistName { get; set; }

		[DataMember(Name = "PlaylistDescription")]
		public string PlaylistDescription { get; set; }

		[DataMember(Name = "PlaylistImageUrl")]
		public AssetContainer PlaylistImageUrl { get; set; }

		[DataMember(Name = "PlaylistId")]
		public uint PlaylistId { get; set; }

		[DataMember(Name = "CurrentSkillRank")]
		public uint? CurrentSkillRank { get; set; }
	}
}
