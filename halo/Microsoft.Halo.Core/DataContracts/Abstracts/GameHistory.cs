using System;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	public abstract class GameHistory
	{
		[JsonProperty("TopMedalIds")]
		public uint[] TopMedalIds { get; set; }

		[JsonProperty("PersonalScore")]
		public int PersonalScore { get; set; }

		[JsonProperty("Id")]
		public string Id { get; set; }

		[JsonProperty("ModeId")]
		public GameMode Mode { get; set; }

		[JsonProperty("ModeName")]
		public string ModeName { get; set; }

		[JsonProperty("Completed")]
		public bool Completed { get; set; }

		[JsonProperty("Result")]
		public GameResult Result { get; set; }

		[JsonProperty("EndDateUtc")]
		public DateTime EndDateUtc { get; set; }
	}
}
