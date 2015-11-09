using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class WarGameDetails
		: GameDetails
	{
		[JsonProperty("Teams")]
		public IReadOnlyCollection<GameTeam> Teams { get; set; }

		[JsonProperty("MapVariantName")]
		public string MapVariantName { get; set; }

		[JsonProperty("PlaylistId")]
		public int PlaylistId { get; set; }

		[JsonProperty("PlaylistName")]
		public string PlaylistName { get; set; }

		[JsonProperty("GameBaseVariantId")]
		public GameBaseVariant GameBaseVariant { get; set; }

		[JsonProperty("GameBaseVariantName")]
		public string GameBaseVariantName { get; set; }

		[JsonProperty("GameVariantName")]
		public string GameVariantName { get; set; }
	}
}
