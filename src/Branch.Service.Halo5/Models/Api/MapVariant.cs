﻿using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class MapVariant
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("mapImageUrl")]
		public string MapImageUrl { get; set; }

		[JsonProperty("mapId")]
		public Guid MapId { get; set; }

		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("contentId")]
		public Nullable<Guid> ContentId { get; set; }
	}
}