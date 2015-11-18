using Branch.Service.Halo5.Models.Api.Abstracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Branch.Service.Halo5.Models.Api
{
	public class Map
		: Result
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("supportedGameModes")]
		public IReadOnlyCollection<string> SupportedGameModes { get; set; }

		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }

		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("contentId")]
		public Nullable<Guid> ContentId { get; set; }
	}
}
