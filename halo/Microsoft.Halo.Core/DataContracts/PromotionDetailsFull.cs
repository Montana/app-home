using System;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class PromotionDetailsFull
	{
		[JsonProperty("Id")]
		public Guid Id { get; set; }

		[JsonProperty("TypeId")]
		public uint TypeId { get; set; }

		[JsonProperty("LifetimeXP")]
		public uint LifetimeXP { get; set; }

		[JsonProperty("LifetimeDoubleXP")]
		public uint LifetimeDoubleXP { get; set; }

		[JsonProperty("TotalDoubleXpGames")]
		public uint TotalDoubleXpGames { get; set; }

		[JsonProperty("TotalNormalXpGames")]
		public uint TotalNormalXpGames { get; set; }
	}
}
