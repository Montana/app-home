using System;
using Branch.Helpers.Converters;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class WeaponStatistic
	{
		[JsonProperty("WeaponId")]
		public WeaponId WeaponId { get; set; }

		[JsonProperty("TotalShotsFired")]
		public int TotalShotsFired { get; set; }

		[JsonProperty("TotalShotsLanded")]
		public int TotalShotsLanded { get; set; }

		[JsonProperty("TotalHeadshots")]
		public int TotalHeadshots { get; set; }

		[JsonProperty("TotalKills")]
		public int TotalKills { get; set; }

		[JsonProperty("TotalDamageDealt")]
		public double TotalDamageDealt { get; set; }

		[JsonConverter(typeof(Iso8601Converter))]
		[JsonProperty("TotalPossessionTime")]
		public TimeSpan TotalPossessionTime { get; set; }
	}
}
