using Branch.Service.Halo5.Models.Api.Enums;
using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class GameVariant
	{
		[JsonProperty("ResourceType")]
		public ResourceType ResourceType { get; set; }

		[JsonProperty("ResourceId")]
		public Guid ResourceId { get; set; }

		[JsonProperty("OwnerType")]
		public OwnerType OwnerType { get; set; }

		[JsonProperty("Owner")]
		public string Owner { get; set; }
	}
}
