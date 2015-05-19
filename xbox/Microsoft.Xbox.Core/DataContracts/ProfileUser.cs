using System;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class ProfileUser
	{
		[JsonProperty("id")]
		public Int64 Xuid { get; set; }

		[JsonProperty("hostId")]
		public string HostId { get; set; }

		[JsonProperty("isSponsoredUser")]
		public bool IsSponsoredUser { get; set; }

		[JsonProperty("settings")]
		public Setting[] Settings { get; set; }
	}
}
