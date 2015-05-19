using System;
using Branch.Helpers.Database;

namespace Branch.Service.XboxLive.Database.Models
{
	public class Authentication :
		Audit
	{
		public string Gamertag { get; set; }

		public string Token { get; set; }

		public Int64 Xuid { get; set; }

		public string UserHash { get; set; }

		public DateTime ExpiresAt { get; set; }
	}
}
