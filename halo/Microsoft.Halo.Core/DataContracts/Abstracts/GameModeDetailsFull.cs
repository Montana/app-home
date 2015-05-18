using System;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	public abstract class GameModeDetailsFull
	{
		public GameModeDetailsFull() { }

		[JsonProperty("Id")]
		public uint Id { get; set; }

		[JsonProperty("TotalDuration")]
		public TimeSpan TotalDuration { get; set; }

		[JsonProperty("TotalKills")]
		public uint TotalKills { get; set; }

		[JsonProperty("TotalDeaths")]
		public uint TotalDeaths { get; set; }

		[JsonProperty("PresentationId")]
		public Presentation Presentation { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("TotalGamesStarted")]
		public uint TotalGamesStarted { get; set; }
	}
}
