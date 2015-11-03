using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class PlaylistDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }

		[JsonProperty("ModeId")]
		public GameMode Mode { get; set; }

		[JsonProperty("ModeName")]
		public string ModeName { get; set; }

		[JsonProperty("MaxPartySize")]
		public uint MaxPartySize { get; set; }

		[JsonProperty("MaxLocalPlayers")]
		public uint MaxLocalPlayers { get; set; }

		[JsonProperty("IsFreeForAll")]
		public bool IsFreeForAll { get; set; }

		[JsonProperty("RelatedGameVariants")]
		public IList<GameVariant> RelatedGameVariants { get; set; }

		[JsonProperty("RelatedMapVariants")]
		public IList<MapVariant> RelatedMapVariants { get; set; }

		[JsonProperty("EffectiveOn")]
		public DateTime EffectiveOn { get; set; }

		[JsonProperty("EffectiveUntil")]
		public DateTime EffectiveUntil { get; set; }
	}
}
