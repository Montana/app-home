using System;
using System.Runtime.Serialization;
using Microsoft.Halo.Core.DataContracts.Abstracts;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class SpartanOpsDetailsFull
		: GameModeDetailsFull
	{
		[DataMember(Name = "TotalSinglePlayerMissionsCompleted")]
		public uint TotalSinglePlayerMissionsCompleted { get; set; }

		[DataMember(Name = "TotalCoopMissionsCompleted")]
		public uint TotalCoopMissionsCompleted { get; set; }

		[DataMember(Name = "TotalMissionsPossible")]
		public uint TotalMissionsPossible { get; set; }

		[DataMember(Name = "TotalMedals")]
		public uint TotalMedals { get; set; }

		[DataMember(Name = "TotalGamesWon")]
		public uint TotalGamesWon { get; set; }
	}
}
