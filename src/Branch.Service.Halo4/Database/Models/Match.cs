using Branch.Helpers.Database;
using Microsoft.Halo.Core.DataContracts.Enums;
using System.Collections.Generic;

namespace Branch.Service.Halo4.Database.Models
{
	public class Match
		: Audit
	{
		public string MatchId { get; set; }

		public GameMode GameMode { get; set; }

		public string DocumentId { get; set; }
		
		public ICollection<ServiceRecordMatch> ServiceRecordMatches { get; set; }
	}
}
