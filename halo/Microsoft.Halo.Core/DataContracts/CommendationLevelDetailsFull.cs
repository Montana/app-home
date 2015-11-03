using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CommendationLevelDetailsFull
	{
		[JsonProperty("CommendationId")]
		public int CommendationId { get; set; }

		[JsonProperty("Level")]
		public int Level { get; set; }

		[JsonProperty("Ticks")]
		public int Ticks { get; set; }

		[JsonProperty("Xp")]
		public int Xp { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
