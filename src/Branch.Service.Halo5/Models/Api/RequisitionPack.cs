using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class RequisitionPack
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("largeImageUrl")]
		public string LargeImageUrl { get; set; }

		[JsonProperty("isFeatured")]
		public bool IsFeatured { get; set; }

		[JsonProperty("isNew")]
		public bool IsNew { get; set; }

		[JsonProperty("creditPrice")]
		public int CreditPrice { get; set; }

		[JsonProperty("isPurchasableWithCredits")]
		public bool IsPurchasableWithCredits { get; set; }

		[JsonProperty("isPurchasableFromMarketplace")]
		public bool IsPurchasableFromMarketplace { get; set; }

		[JsonProperty("xboxMarketplaceProductId")]
		public Nullable<Guid> XboxMarketplaceProductId { get; set; }

		[JsonProperty("xboxMarketplaceProductUrl")]
		public string XboxMarketplaceProductUrl { get; set; }

		[JsonProperty("merchandisingOrder")]
		public int MerchandisingOrder { get; set; }

		[JsonProperty("flair")]
		public object Flair { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("contentId")]
		public string ContentId { get; set; }
	}
}
