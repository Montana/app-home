using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class CampaignDetailsFull
		: GameModeDetailsFull
	{
		[DataMember(Name = "DifficultyLevels")]
		public IReadOnlyCollection<DifficultyLevel> DifficultyLevels { get; set; }

		[DataMember(Name = "SinglePlayerMissions")]
		public IReadOnlyCollection<Mission> SinglePlayerMissions { get; set; }

		[DataMember(Name = "CoopMissions")]
		public IReadOnlyCollection<Mission> CoopMissions { get; set; }

		[DataMember(Name = "TotalTerminalsVisited")]
		public uint TotalTerminalsVisited { get; set; }

		[DataMember(Name = "NarrativeFlags")]
		public ulong NarrativeFlags { get; set; }

		[DataMember(Name = "SinglePlayerDifficulty")]
		public Difficulty SinglePlayerDifficulty { get; set; }

		[DataMember(Name = "CoopDifficulty")]
		public Difficulty CoopDifficulty { get; set; }
	}
}
