using System;
using Branch.Helpers.Database;
using Branch.Service.Halo5.Database.Enums;

namespace Branch.Service.Halo5.Database.Models
{
	public class ServiceRecord
		: Audit
	{
		public Int64 Xuid { get; set; }

		public string DocumentId { get; set; }

		public ServiceRecordType Type { get; set; }

		public int TotalKills { get; set; }

		public int TotalDeaths { get; set; }

		public double TotalDamage { get; set; }

		public int TotalGamesCompleted { get; set; }

		public int TotalGamesLost { get; set; }

		public int TotalGamesTied { get; set; }

		public int TotalGamesWon { get; set; }

		public TimeSpan TotalPlaytime { get; set; }

		#region [ Player ]

		public int PlayerId { get; set; }

		public Player Player { get; set; }

		#endregion
	}
}
