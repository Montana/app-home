using Branch.Helpers.Database;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Service.Halo4.Database.Models
{
	public class Match
		: Audit
	{
		public GameMode GameMode { get; set; }

		public string DocumentId { get; set; }

		#region [ Service Record ]

		public int ServiceRecordId { get; set; }

		public ServiceRecord ServiceRecord { get; set; }

		#endregion
	}
}
