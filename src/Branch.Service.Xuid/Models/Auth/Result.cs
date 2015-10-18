using Newtonsoft.Json;

namespace Branch.Service.Xuid.Models.Auth
{
	public class Result
	{
		[JsonProperty("access_token")]
		public string Token { get; set; }
	}
}
