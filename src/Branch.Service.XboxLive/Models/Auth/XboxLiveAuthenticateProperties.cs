using Newtonsoft.Json;

namespace Branch.Service.XboxLive.Models.Auth
{
	public class XboxLiveAuthenticateProperties
	{
		[JsonProperty("AuthMethod")]
		public string AuthMethod { get; set; }

		[JsonProperty("RpsTicket")]
		public string RpsTicket { get; set; }

		[JsonProperty("SiteName")]
		public string SiteName { get; set; }
	}
}
