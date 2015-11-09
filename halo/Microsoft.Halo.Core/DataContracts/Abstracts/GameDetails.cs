using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	public abstract class GameDetails
	{
		[JsonProperty("Duration")]
		public TimeSpan Duration { get; set; }

		[JsonProperty("TotalPlayers")]
		public uint TotalPlayers { get; set; }

		[JsonProperty("Players")]
		public IReadOnlyCollection<GamePlayer> Players { get; set; }

		[JsonProperty("MapId")]
		public uint MapId { get; set; }

		[JsonProperty("MapName")]
		public string MapName { get; set; }

		[JsonProperty("MapImageUrl")]
		public AssetContainer MapImageUrl { get; set; }

		[JsonProperty("Id")]
		public string Id { get; set; }

		[JsonProperty("ModeId")]
		public GameMode Mode { get; set; }

		[JsonProperty("ModeName")]
		public string ModeName { get; set; }

		[JsonProperty("Completed")]
		public bool Completed { get; set; }

		[JsonProperty("Result")]
		public int Result { get; set; }

		[JsonProperty("EndDateUtc")]
		public DateTime EndDateUtc { get; set; }
	}
}
