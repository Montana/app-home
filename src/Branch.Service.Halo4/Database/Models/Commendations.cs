using Branch.Helpers.Database;
using System;

namespace Branch.Service.Halo4.Database.Models
{
	public class Commendations
		: Audit
	{
		public string DocumentId { get; set; }

		#region [ Service Record ]

		public int ServiceRecordId { get; set; }

		public ServiceRecord ServiceRecord { get; set; }

		#endregion
	}
}
