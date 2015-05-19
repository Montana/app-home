using System;
using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class PlayedActivityItem
		: ActivityItem
	{
		[JsonProperty("startTime")]
		public DateTime StartTime { get; set; }

		[JsonProperty("endTime")]
		public DateTime EndTime { get; set; }

		[JsonProperty("sessionDurationInMinutes")]
		public string SessionDurationInMinutes { get; set; }
		
		[JsonProperty("userImageUriMd")]
		public string UserImageUriMd { get; set; }

		[JsonProperty("userImageUriXs")]
		public string UserImageUriXs { get; set; }
		
		[JsonProperty("gamertag")]
		public string Gamertag { get; set; }

		[JsonProperty("realName")]
		public string RealName { get; set; }

		[JsonProperty("displayName")]
		public string DisplayName { get; set; }
	}
}
