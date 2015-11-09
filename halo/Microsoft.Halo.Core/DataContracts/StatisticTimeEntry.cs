using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class StatisticTimeEntry
	{
		[JsonProperty("Time")]
		public int Time { get; set; }

		[JsonProperty("Ticks")]
		public int Ticks { get; set; }
	}
}
