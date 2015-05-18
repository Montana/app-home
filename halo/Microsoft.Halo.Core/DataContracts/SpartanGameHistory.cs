using System;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpartanGameHistory
		: GameHistory
	{
		[JsonProperty("EpisodeName")]
		public string EpisodeName { get; set; }

		[JsonProperty("ChapterName")]
		public string ChapterName { get; set; }

		[JsonProperty("Difficulty")]
		public Difficulty Difficulty { get; set; }

		[JsonProperty("DifficultyImageUrl")]
		public AssetContainer DifficultyImageUrl { get; set; }

		[JsonProperty("SinglePlayer")]
		public bool SinglePlayer { get; set; }

		[JsonProperty("Duration")]
		public TimeSpan Duration { get; set; }

		[JsonProperty("SeasonId")]
		public uint SeasonId { get; set; }

		[JsonProperty("EpisodeId")]
		public uint EpisodeId { get; set; }

		[JsonProperty("ChapterId")]
		public uint ChapterId { get; set; }

		[JsonProperty("ChapterNumber")]
		public uint ChapterNumber { get; set; }
	}
}
