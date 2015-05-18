using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CampaignDetailsFull
		: GameModeDetailsFull
	{
		[JsonProperty("DifficultyLevels")]
		public IReadOnlyCollection<DifficultyLevelDetailsFull> DifficultyLevels { get; set; }

		[JsonProperty("SinglePlayerMissions")]
		public IReadOnlyCollection<MissionDetailsFull> SinglePlayerMissions { get; set; }

		[JsonProperty("CoopMissions")]
		public IReadOnlyCollection<MissionDetailsFull> CoopMissions { get; set; }

		[JsonProperty("TotalTerminalsVisited")]
		public uint TotalTerminalsVisited { get; set; }

		[JsonProperty("NarrativeFlags")]
		public ulong NarrativeFlags { get; set; }

		[JsonProperty("SinglePlayerDifficulty")]
		public Difficulty? SinglePlayerDifficulty { get; set; }

		[JsonProperty("CoopDifficulty")]
		public Difficulty? CoopDifficulty { get; set; }
	}
}
