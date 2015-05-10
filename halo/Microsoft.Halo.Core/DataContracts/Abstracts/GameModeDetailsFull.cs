using System;
using System.Runtime.Serialization;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	[DataContract]
	public abstract class GameModeDetailsFull
	{
		public GameModeDetailsFull() { }

		[DataMember(Name = "Id")]
		public uint Id { get; set; }

		[DataMember(Name = "TotalDuration")]
		public TimeSpan TotalDuration { get; set; }

		[DataMember(Name = "TotalKills")]
		public uint TotalKills { get; set; }

		[DataMember(Name = "TotalDeaths")]
		public uint TotalDeaths { get; set; }

		[DataMember(Name = "PresentationId")]
		public Presentation Presentation { get; set; }

		[DataMember(Name = "Name")]
		public string Name { get; set; }

		[DataMember(Name = "TotalGamesStarted")]
		public uint TotalGamesStarted { get; set; }
	}
}
