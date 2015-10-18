﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Branch.Service.Xuid.Models.Auth
{
	public class XboxLiveAuthorizeResponse
	{
		[JsonProperty("IssueInstant")]
		public DateTime IssueInstant { get; set; }

		[JsonProperty("NotAfter")]
		public DateTime NotAfter { get; set; }

		[JsonProperty("Token")]
		public string Token { get; set; }

		[JsonProperty("DisplayClaims")]
		public Dictionary<string, Dictionary<string, string>[]> DisplayClaims { get; set; }
	}
}