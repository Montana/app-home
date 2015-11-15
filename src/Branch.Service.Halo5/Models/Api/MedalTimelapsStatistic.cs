using System;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class MedalTimelapsStatistic
	{
		[JsonProperty("Id")]
		public Int64 Id { get; set; }

		[JsonProperty("Timelapse")]
		public string Timelapse { get; set; }
	}
}
