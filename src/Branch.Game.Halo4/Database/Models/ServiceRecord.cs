using System;
using Branch.Helpers.Database;

namespace Branch.Game.Halo4.Database.Models
{
	public class ServiceRecord
		: Audit
	{
		public string Gamertag { get; set; }

		public string ServiceTag { get; set; }

		public string DocumentId { get; set; }
	}
}
