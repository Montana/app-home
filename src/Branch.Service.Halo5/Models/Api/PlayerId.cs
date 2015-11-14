using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class PlayerId
	{
		[JsonProperty("Gamertag")]
		public string Gamertag { get; set; }

		[JsonProperty("Xuid")]
		public Int64 Xuid { get; set; }
	}
}
