using System;
using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CampaignDetailsFull
		: GameModeDetailsFull
	{
		public IReadOnlyCollection<DifficultyLevel> DifficultyLevels { get; set; }

		public IReadOnlyCollection<Mission> SinglePlayerMissions { get; set; }

		public IReadOnlyCollection<Mission> CoopMissions { get; set; }

		public uint TotalTerminalsVisited { get; set; }

		public ulong NarrativeFlags { get; set; }

		public Difficulty SinglePlayerDifficulty { get; set; }

		public Difficulty CoopDifficulty { get; set; }
	}
}
