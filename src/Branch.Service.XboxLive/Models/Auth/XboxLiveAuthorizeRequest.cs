using Newtonsoft.Json;

namespace Branch.Service.XboxLive.Models.Auth
{
	public class XboxLiveAuthorizeRequest
	{
		[JsonProperty("RelyingParty")]
		public string RelyingParty { get; set; }

		[JsonProperty("TokenType")]
		public string TokenType { get; set; }

		[JsonProperty("Properties")]
		public XboxLiveAuthorizeProperties Properties { get; set; }
	}
}
