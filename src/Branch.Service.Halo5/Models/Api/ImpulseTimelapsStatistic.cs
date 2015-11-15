using System;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ImpulseTimelapsStatistic
	{
		[JsonProperty("Id")]
		public Guid Id { get; set; }

		[JsonProperty("Timelapse")]
		public string Timelapse { get; set; }
	}
}
