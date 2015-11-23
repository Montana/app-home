using Branch.Service.Halo5.Models.Api.Abstracts;
using Branch.Service.Halo5.Models.Api.Enums;
using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class Playlist
		: Result
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("isRanked")]
		public bool IsRanked { get; set; }

		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }

		[JsonProperty("gameMode")]
		public GameMode GameMode { get; set; }

		[JsonProperty("isActive")]
		public bool IsActive { get; set; }

		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("contentId")]
		public Nullable<Guid> ContentId { get; set; }
	}
}
