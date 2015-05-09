using Microsoft.Halo.Core.DataContracts.Abstracts;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpartanOpsDetailsFull
		: GameModeDetailsFull
	{
		public uint TotalSinglePlayerMissionsCompleted { get; set; }

		public uint TotalCoopMissionsCompleted { get; set; }

		public uint TotalMissionsPossible { get; set; }

		public uint TotalMedals { get; set; }

		public uint TotalGamesWon { get; set; }
	}
}
