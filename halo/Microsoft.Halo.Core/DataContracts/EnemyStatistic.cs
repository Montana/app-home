using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class EnemyStatistic
	{
		[JsonProperty("EnemyId")]
		public int EnemyId { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }

		[JsonProperty("Kills")]
		public int Kills { get; set; }

		[JsonProperty("Deaths")]
		public int Deaths { get; set; }

		[JsonProperty("AverageKillDistance")]
		public double AverageKillDistance { get; set; }

		[JsonProperty("AverageDeathDistance")]
		public double AverageDeathDistance { get; set; }
	}
}