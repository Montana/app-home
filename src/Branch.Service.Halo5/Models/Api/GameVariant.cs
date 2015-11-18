using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class GameVariant
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("iconUrl")]
		public string IconUrl { get; set; }

		[JsonProperty("gameBaseVariantId")]
		public Guid GameBaseVariantId { get; set; }

		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("contentId")]
		public Nullable<Guid> ContentId { get; set; }
	}
}
