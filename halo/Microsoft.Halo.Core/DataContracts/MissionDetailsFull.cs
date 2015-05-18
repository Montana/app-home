using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class MissionDetailsFull
	{
		[JsonProperty("MapId")]
		public int MapId { get; set; }

		[JsonProperty("Mission")]
		public int MissionId { get; set; }

		[JsonProperty("Difficulty")]
		public Difficulty Difficilty { get; set; }
	}
}
