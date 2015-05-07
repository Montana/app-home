using System;
using Branch.Helpers.Database;

namespace Branch.Service.Halo4.Database.Models
{
	public class Authentication :
		Audit
	{
		public string SpartanToken { get; set; }

		public string AnalyticsToken { get; set; }

		public string Gamertag { get; set; }

		public DateTime ExpiresAt { get; set; }
	}
}
