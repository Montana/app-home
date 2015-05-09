using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class Mission
	{
		public int MapId { get; set; }

		[JsonProperty("Mission")]
		public int MissionId { get; set; }

		public Difficulty Difficilty { get; set; }
	}
}
