using Newtonsoft.Json;

namespace Branch.Service.XboxLive.Models.Auth
{
	public class Result
	{
		[JsonProperty("access_token")]
		public string Token { get; set; }
	}
}
