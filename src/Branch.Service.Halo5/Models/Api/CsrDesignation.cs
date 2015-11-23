using Branch.Service.Halo5.Models.Api.Abstracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Branch.Service.Halo5.Models.Api
{
	public class CsrDesignation
		: Result
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("bannerImageUrl")]
		public string BannerImageUrl { get; set; }

		[JsonProperty("tiers")]
		public IReadOnlyCollection<CsrDesignationTier> Tiers { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("contentId")]
		public Nullable<Guid> ContentId { get; set; }
	}
}
