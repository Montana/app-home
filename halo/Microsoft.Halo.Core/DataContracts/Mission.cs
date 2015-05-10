using System.Runtime.Serialization;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class Mission
	{
		[DataMember(Name = "MapId")]
		public int MapId { get; set; }

		[DataMember(Name = "Mission")]
		public int MissionId { get; set; }

		[DataMember(Name = "Difficulty")]
		public Difficulty Difficilty { get; set; }
	}
}
