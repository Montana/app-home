using System;
using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Abstracts;

namespace Microsoft.Halo.Core.DataContracts
{
	public class WarGameHistory
		: GameHistory
	{
		public int Standing { get; set; }

		public int BaseVariantId { get; set; }

		public AssetContainer BaseVariantImageUrl { get; set; }

		public string VariantName { get; set; }

		public string FeaturedStatName { get; set; }

		public string FeaturedStatValue { get; set; }

		public IReadOnlyCollection<Guid> PromotionIds { get; set; }

		public int TotalMedals { get; set; }

		public string MapVariantName { get; set; }

		public uint PlayListId { get; set; }

		public string PlayListName { get; set; }
	}
}
