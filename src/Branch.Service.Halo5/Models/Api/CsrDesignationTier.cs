using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class CsrDesignationTier
	{
		[JsonProperty("iconImageUrl")]
		public string IconImageUrl { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("contentId")]
		public Nullable<Guid> ContentId { get; set; }
	}
}
