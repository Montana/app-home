using System;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	public abstract class GameModeDetailsFull
	{
		public TimeSpan TotalDuration { get; set; }

		public uint TotalKills { get; set; }

		public uint TotalDeaths { get; set; }

		[JsonProperty("PresentationId")]
		public Presentation Presentation { get; set; }

		public uint Id { get; set; }

		public string Name { get; set; }

		public uint TotalGamesStarted { get; set; }
	}
}
