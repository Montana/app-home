using Branch.Service.Halo5.Models.Api.Abstracts;
using Branch.Service.Halo5.Models.Api.Enums;
using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class Weapon
		: Result
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("type")]
		public WeaponType Type { get; set; }

		[JsonProperty("largeIconImageUrl")]
		public string LargeIconImageUrl { get; set; }

		[JsonProperty("smallIconImageUrl")]
		public string SmallIconImageUrl { get; set; }

		[JsonProperty("isUsableByPlayer")]
		public bool IsUsableByPlayer { get; set; }

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("contentId")]
		public Nullable<Guid> ContentId { get; set; }
	}
}
