using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
    public class EnemyKillsStatistic
    {
		[JsonProperty("Enemy")]
		public EnemyId Enemy { get; set; }

		[JsonProperty("TotalKills")]
		public int TotalKills { get; set; }
	}
}
