using Newtonsoft.Json;

namespace Branch.Service.Xuid.Models.Auth
{
	public class WindowsLiveRequest
	{
		[JsonProperty("MicrosoftAccount")]
		public string MicrosoftAccount { get; set; }

		[JsonProperty("MicrosoftAccountPassword")]
		public string MicrosoftAccountPassword { get; set; }
	}
}
