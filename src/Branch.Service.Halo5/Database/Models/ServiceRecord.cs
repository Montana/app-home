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
	}
}
