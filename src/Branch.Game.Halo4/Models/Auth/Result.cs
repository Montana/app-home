using Newtonsoft.Json;

namespace Branch.Game.Halo4.Models.Auth
{
	public class Result
	{
		public string SpartanToken { get; set; }

		public string AnalyticsToken { get; set; }

		public string Gamertag { get; set; }
	}
}
