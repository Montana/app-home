using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class ProfileSummary
		: Response
	{
		[JsonProperty("targetFollowingCount")]
		public int TargetFollowingCount { get; set; }

		[JsonProperty("targetFollowerCount")]
		public int TargetFollowerCount { get; set; }

		[JsonProperty("isCallerFollowingTarget")]
		public bool IsCallerFollowingTarget { get; set; }

		[JsonProperty("isTargetFollowingCaller")]
		public bool IsTargetFollowingCaller { get; set; }

		[JsonProperty("hasCallerMarkedTargetAsFavorite")]
		public bool HasCallerMarkedTargetAsFavorite { get; set; }

		[JsonProperty("hasCallerMarkedTargetAsIdentityShared")]
		public bool HasCallerMarkedTargetAsIdentityShared { get; set; }

		[JsonProperty("legacyFriendStatus")]
		public string LegacyFriendStatus { get; set; }
	}
}
