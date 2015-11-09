using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class GamePlayer
	{
		[JsonProperty("DeathsOverTime")]
		public IReadOnlyCollection<StatisticTimeEntry> DeathsOverTime { get; set; }

		[JsonProperty("KillsOverTime")]
		public IReadOnlyCollection<StatisticTimeEntry> KillsOverTime { get; set; }

		[JsonProperty("MedalsOverTime")]
		public IReadOnlyCollection<StatisticTimeEntry> MedalsOverTime { get; set; }

		[JsonProperty("MedalStats")]
		public IReadOnlyCollection<MedalStatistic> MedalStats { get; set; }

		[JsonProperty("DamageTypeStats")]
		public IReadOnlyCollection<DamageTypeStatistic> DamageTypeStats { get; set; }

		[JsonProperty("EnemyStats")]
		public IReadOnlyCollection<EnemyStatistic> EnemyStats { get; set; }

		[JsonProperty("SkillRank")]
		public object SkillRank { get; set; }

		[JsonProperty("TeamId")]
		public int TeamId { get; set; }

		[JsonProperty("IsCompleted")]
		public bool IsCompleted { get; set; }

		[JsonProperty("Servicetag")]
		public string Servicetag { get; set; }

		[JsonProperty("IsGuest")]
		public bool IsGuest { get; set; }

		[JsonProperty("JoinedInProgress")]
		public bool JoinedInProgress { get; set; }

		[JsonProperty("Standing")]
		public int Standing { get; set; }

		[JsonProperty("Result")]
		public GameResult Result { get; set; }

		[JsonProperty("PersonalScore")]
		public int PersonalScore { get; set; }

		[JsonProperty("FeaturedStatName")]
		public string FeaturedStatName { get; set; }

		[JsonProperty("FeaturedStatValue")]
		public int FeaturedStatValue { get; set; }

		[JsonProperty("StandingInTeam")]
		public int StandingInTeam { get; set; }

		[JsonProperty("Kills")]
		public int Kills { get; set; }

		[JsonProperty("Deaths")]
		public int Deaths { get; set; }

		[JsonProperty("Assists")]
		public int Assists { get; set; }

		[JsonProperty("Headshots")]
		public int Headshots { get; set; }

		[JsonProperty("Betrayals")]
		public int Betrayals { get; set; }

		[JsonProperty("Suicides")]
		public int Suicides { get; set; }

		[JsonProperty("KilledMostGamertag")]
		public string KilledMostGamertag { get; set; }

		[JsonProperty("KilledMostCount")]
		public int KilledMostCount { get; set; }

		[JsonProperty("KilledByMostGamertag")]
		public string KilledByMostGamertag { get; set; }

		[JsonProperty("KilledByMostCount")]
		public int KilledByMostCount { get; set; }

		[JsonProperty("RankId")]
		public int RankId { get; set; }

		[JsonProperty("RankName")]
		public string RankName { get; set; }

		[JsonProperty("RankUrl")]
		public AssetContainer RankUrl { get; set; }

		[JsonProperty("EmblemImageUrl")]
		public AssetContainer EmblemImageUrl { get; set; }

		[JsonProperty("FirstPlayedUtc")]
		public DateTime FirstPlayedUtc { get; set; }

		[JsonProperty("LastPlayedUtc")]
		public DateTime LastPlayedUtc { get; set; }

		[JsonProperty("AverageDeathDistance")]
		public double AverageDeathDistance { get; set; }

		[JsonProperty("AverageKillDistance")]
		public double AverageKillDistance { get; set; }

		[JsonProperty("TotalMedals")]
		public int TotalMedals { get; set; }

		[JsonProperty("TotalKillMedals")]
		public int TotalKillMedals { get; set; }

		[JsonProperty("TotalBonusMedals")]
		public int TotalBonusMedals { get; set; }

		[JsonProperty("TotalAssistMedals")]
		public int TotalAssistMedals { get; set; }

		[JsonProperty("TotalSpreeMedals")]
		public int TotalSpreeMedals { get; set; }

		[JsonProperty("TotalModeMedals")]
		public int TotalModeMedals { get; set; }

		[JsonProperty("TopMedalIds")]
		public IReadOnlyCollection<int> TopMedalIds { get; set; }

		[JsonProperty("Gamertag")]
		public string Gamertag { get; set; }
	}
}
