using System;
using Branch.Helpers.Database;

namespace Branch.Service.Xuid.Database.Models
{
	public class XuidCache :
		Audit
	{
		public string Gamertag { get; set; }
		
		public Int64 Xuid { get; set; }

		public DateTime ExpiresAt { get; set; }
	}
}
