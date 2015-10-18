using Newtonsoft.Json;

namespace Branch.Service.Xuid.Models.Auth
{
	public class XboxLiveAuthorizeProperties
	{
		[JsonProperty("SandboxId")]
		public string SandboxId { get; set; }

		[JsonProperty("UserTokens")]
		public string[] UserTokens { get; set; }
	}
}
