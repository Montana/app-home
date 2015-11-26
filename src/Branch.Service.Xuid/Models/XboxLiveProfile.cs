using System;

namespace Branch.Service.Xuid.Models
{
	public class XboxLiveProfile
	{
		public string Gamertag { get; set; }

		public long Xuid { get; set; }

		public DateTime CachedAt { get; set; }
	}
}
