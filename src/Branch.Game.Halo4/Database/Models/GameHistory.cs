using System;
using Branch.Helpers.Database;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Game.Halo4.Database.Models
{
	public class GameHistory
		: Audit
	{
		public int Count { get; set; }

		public int StartAt { get; set; }

		public Nullable<GameMode> GameMode { get; set; }

		public string DocumentId { get; set; }

		#region [ Service Record ]

		public int ServiceRecordId { get; set; }

		public ServiceRecord ServiceRecord { get; set; }

		#endregion
	}
}
