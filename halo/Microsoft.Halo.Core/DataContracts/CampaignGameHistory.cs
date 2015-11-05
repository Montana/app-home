using System;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CampaignGameHistory
		: GameHistory
	{
		[JsonProperty("MapId")]
		public uint MapId { get; set; }

		[JsonProperty("MapImageUrl")]
		public AssetContainer MapImageUrl { get; set; }

		[JsonProperty("DifficultyImageUrl")]
		public AssetContainer DifficultyImageUrl { get; set; }

		[JsonProperty("SkullIds")]
		public uint[] SkullIds { get; set; }

		[JsonProperty("Duration")]
		public TimeSpan Duration { get; set; }

		[JsonProperty("MissionId")]
		public uint MissionId { get; set; }

		[JsonProperty("MapName")]
		public string MapName { get; set; }

		[JsonProperty("Difficulty")]
		public Difficulty Difficulty { get; set; }

		[JsonProperty("SinglePlayer")]
		public bool SinglePlayer { get; set; }
	}
}
