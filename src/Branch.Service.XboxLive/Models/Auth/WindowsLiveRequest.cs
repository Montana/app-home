using Newtonsoft.Json;

namespace Branch.Service.XboxLive.Models.Auth
{
	public class WindowsLiveRequest
	{
		[JsonProperty("MicrosoftAccount")]
		public string MicrosoftAccount { get; set; }

		[JsonProperty("MicrosoftAccountPassword")]
		public string MicrosoftAccountPassword { get; set; }
	}
}
