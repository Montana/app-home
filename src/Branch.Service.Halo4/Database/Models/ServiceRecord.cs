using System;
using System.Collections.Generic;
using Branch.Helpers.Database;

namespace Branch.Service.Halo4.Database.Models
{
	public class ServiceRecord
		: Audit
	{
		public Int64 Xuid { get; set; }

		public string ServiceTag { get; set; }

		public string DocumentId { get; set; }

		public ICollection<GameHistory> GameHistories { get; set; }

		#region [ Commendations ]

		public Nullable<int> CommendationsId { get; set; }

		public Commendations Commendations { get; set; }

		#endregion
	}
}
