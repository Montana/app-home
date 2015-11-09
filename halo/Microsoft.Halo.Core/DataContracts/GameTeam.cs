using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class GameTeam
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("EmblemImageUrl")]
		public AssetContainer EmblemImageUrl { get; set; }

		[JsonProperty("PrimaryRGB")]
		public string PrimaryRGB { get; set; }

		[JsonProperty("PrimaryRGBA")]
		public int PrimaryRGBA { get; set; }

		[JsonProperty("SecondaryRGB")]
		public string SecondaryRGB { get; set; }

		[JsonProperty("SecondaryRGBA")]
		public int SecondaryRGBA { get; set; }

		[JsonProperty("Standing")]
		public int Standing { get; set; }

		[JsonProperty("Score")]
		public int Score { get; set; }

		[JsonProperty("Kills")]
		public int Kills { get; set; }

		[JsonProperty("Deaths")]
		public int Deaths { get; set; }

		[JsonProperty("Assists")]
		public int Assists { get; set; }

		[JsonProperty("Betrayals")]
		public int Betrayals { get; set; }

		[JsonProperty("Suicides")]
		public int Suicides { get; set; }

		[JsonProperty("DeathsOverTime")]
		public IReadOnlyCollection<StatisticTimeEntry> DeathsOverTime { get; set; }

		[JsonProperty("KillsOverTime")]
		public IReadOnlyCollection<StatisticTimeEntry> KillsOverTime { get; set; }

		[JsonProperty("MedalsOverTime")]
		public IReadOnlyCollection<StatisticTimeEntry> MedalsOverTime { get; set; }

		[JsonProperty("TotalMedals")]
		public int TotalMedals { get; set; }

		[JsonProperty("MedalStats")]
		public IReadOnlyCollection<MedalStatistic> MedalStats { get; set; }
	}
}
