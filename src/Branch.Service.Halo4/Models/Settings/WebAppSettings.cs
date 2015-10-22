using Newtonsoft.Json;
using System.Collections.Generic;

namespace Branch.Service.Halo4.Models.Settings
{
	public class WebAppSettings
	{
		[JsonProperty("ResponseCode")]
		public int ResponseCode { get; set; }

		[JsonProperty("TokenResponseCode")]
		public int TokenResponseCode { get; set; }

		[JsonProperty("Identifier")]
		public string Identifier { get; set; }

		[JsonProperty("State")]
		public int State { get; set; }

		[JsonProperty("ClientStatusMessage")]
		public string ClientStatusMessage { get; set; }

		[JsonProperty("ServiceList")]
		public Dictionary<string, string> ServiceList { get; set; }

		[JsonProperty("Settings")]
		public Dictionary<string, string> Settings { get; set; }

		[JsonProperty("SpartanToken")]
		public string SpartanToken { get; set; }
	}
}
