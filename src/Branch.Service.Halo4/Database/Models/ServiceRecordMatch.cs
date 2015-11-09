namespace Branch.Service.Halo4.Database.Models
{
	public class ServiceRecordMatch
	{
		public int ServiceRecordId { get; set; }
		public ServiceRecord ServiceRecord { get; set; }

		public int MatchId { get; set; }
		public Match Match { get; set; }
	}
}
