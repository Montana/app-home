using System;
using System.Collections.Generic;
using Branch.Helpers.Database;

namespace Branch.Service.Halo5.Database.Models
{
	public class Player
		: Audit
	{
		public Int64 Xuid { get; set; }

		public string ServiceTag { get; set; }

		public long Xp { get; set; }

		public long SpartanRank { get; set; }

		public ICollection<ServiceRecord> ServiceRecords { get; set; }
	}
}
