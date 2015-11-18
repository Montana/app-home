using System;
using Branch.Helpers.Database;
using Branch.Service.Halo5.Models.Api.Enums;

namespace Branch.Service.Halo5.Database.Models
{
	public class MatchHistory
		: Audit
	{
		public Int64 Xuid { get; set; }

		public string DocumentId { get; set; }

		public GameMode Mode { get; set; }

		public int Start { get; set; }

		public int Count { get; set; }
	}
}
