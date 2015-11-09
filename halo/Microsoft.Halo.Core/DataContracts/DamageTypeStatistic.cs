using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class DamageTypeStatistic
	{
		[JsonProperty("Id")]
		public int Id { get; set; }
		
		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }

		[JsonProperty("Kills")]
		public int Kills { get; set; }

		[JsonProperty("Deaths")]
		public int Deaths { get; set; }

		[JsonProperty("Headshots")]
		public int Headshots { get; set; }

		[JsonProperty("Betrayals")]
		public int Betrayals { get; set; }

		[JsonProperty("Suicides")]
		public int Suicides { get; set; }
	}
}
