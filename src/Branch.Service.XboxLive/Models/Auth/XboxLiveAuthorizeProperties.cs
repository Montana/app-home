using Newtonsoft.Json;

namespace Branch.Service.XboxLive.Models.Auth
{
	public class XboxLiveAuthorizeProperties
	{
		[JsonProperty("SandboxId")]
		public string SandboxId { get; set; }

		[JsonProperty("UserTokens")]
		public string[] UserTokens { get; set; }
	}
}
