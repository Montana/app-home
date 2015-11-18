using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class PlayerId
	{
		[JsonProperty("Gamertag")]
		public string Gamertag { get; set; }

		[JsonProperty("Xuid")]
		public Nullable<Int64> Xuid { get; set; }
		
		[JsonIgnore]
		public string Emblem { get; set; }

		[JsonIgnore]
		public string SpartanModel { get; set; }
	}
}
