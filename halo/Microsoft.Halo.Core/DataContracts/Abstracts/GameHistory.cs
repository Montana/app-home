using System;
using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	public abstract class GameHistory
	{
		public uint MapId { get; set; }

		public AssetContainer MapImageUrl { get; set; }

		public IReadOnlyCollection<uint> TopMedalIds { get; set; }

		public uint PersonalScore { get; set; }

		public string Id { get; set; }

		[JsonProperty("ModeId")]
		public GameMode GameMode { get; set; }

		public string ModeName { get; set; }

		public bool Completed { get; set; }

		public int Result { get; set; }

		public DateTime EndDateUtc { get; set; }
	}
}
