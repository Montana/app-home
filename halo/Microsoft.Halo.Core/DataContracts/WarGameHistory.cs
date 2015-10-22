using System;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class WarGameHistory
		: GameHistory
	{
		[JsonProperty("Standing")]
		public int Standing { get; set; }

		[JsonProperty("BaseVariantId")]
		public int BaseVariantId { get; set; }

		[JsonProperty("BaseVariantImageUrl")]
		public AssetContainer BaseVariantImageUrl { get; set; }

		[JsonProperty("VariantName")]
		public string VariantName { get; set; }

		[JsonProperty("FeaturedStatName")]
		public string FeaturedStatName { get; set; }

		[JsonProperty("FeaturedStatValue")]
		public int FeaturedStatValue { get; set; }

		[JsonProperty("PromotionIds")]
		public int[] PromotionIds { get; set; }

		[JsonProperty("TotalMedals")]
		public uint TotalMedals { get; set; }

		[JsonProperty("MapId")]
		public uint MapId { get; set; }

		[JsonProperty("MapImageUrl")]
		public AssetContainer MapImageUrl { get; set; }

		[JsonProperty("MapVariantName")]
		public string MapVariantName { get; set; }

		[JsonProperty("PlayListId")]
		public int PlaylistId { get; set; }

		[JsonProperty("PlayListName")]
		public string PlaylistName { get; set; }
	}
}
