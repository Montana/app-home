using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpartanOpsMetadata
	{
		[JsonProperty("SeasonsReleasedToDate")]
		public int SeasonsReleasedToDate { get; set; }

		[JsonProperty("ChaptersCurrentlyAvailable")]
		public int ChaptersCurrentlyAvailable { get; set; }

		[JsonProperty("BumperType")]
		public int BumperType { get; set; }

		[JsonProperty("CurrentSeason")]
		public int CurrentSeason { get; set; }

		[JsonProperty("CurrentEpisode")]
		public int CurrentEpisode { get; set; }

		[JsonProperty("Seasons")]
		public IReadOnlyCollection<SpartanOpsSeasonDetailsFull> Seasons { get; set; }
	}
}
