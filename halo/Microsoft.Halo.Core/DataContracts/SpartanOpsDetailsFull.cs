using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpartanOpsDetailsFull
		: GameModeDetailsFull
	{
		[JsonProperty("TotalSinglePlayerMissionsCompleted")]
		public uint TotalSinglePlayerMissionsCompleted { get; set; }

		[JsonProperty("TotalCoopMissionsCompleted")]
		public uint TotalCoopMissionsCompleted { get; set; }

		[JsonProperty("TotalMissionsPossible")]
		public uint TotalMissionsPossible { get; set; }

		[JsonProperty("TotalMedals")]
		public uint TotalMedals { get; set; }

		[JsonProperty("TotalGamesWon")]
		public uint TotalGamesWon { get; set; }
	}
}
