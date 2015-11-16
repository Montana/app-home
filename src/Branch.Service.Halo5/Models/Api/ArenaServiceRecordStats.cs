﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ArenaServiceRecordStats
	{
		[JsonProperty("ArenaPlaylistStats")]
		public IReadOnlyCollection<ArenaPlaylistStatistics> ArenaPlaylistStats { get; set; }

		[JsonProperty("HighestCsrAttained")]
		public CsrStatistic HighestCsrAttained { get; set; }

		[JsonProperty("ArenaGameBaseVariantStats")]
		public IReadOnlyCollection<ArenaGameBaseVariantStatistics> ArenaGameBaseVariantStats { get; set; }

		[JsonProperty("TopGameBaseVariants")]
		public IReadOnlyCollection<GameBaseVariantStatistics> TopGameBaseVariants { get; set; }

		[JsonProperty("HighestCsrPlaylistId")]
		public string HighestCsrPlaylistId { get; set; }

		[JsonProperty("TotalKills")]
		public int TotalKills { get; set; }

		[JsonProperty("TotalHeadshots")]
		public int TotalHeadshots { get; set; }

		[JsonProperty("TotalWeaponDamage")]
		public double TotalWeaponDamage { get; set; }

		[JsonProperty("TotalShotsFired")]
		public int TotalShotsFired { get; set; }

		[JsonProperty("TotalShotsLanded")]
		public int TotalShotsLanded { get; set; }

		[JsonProperty("WeaponWithMostKills")]
		public WeaponStatistic WeaponWithMostKills { get; set; }

		[JsonProperty("TotalMeleeKills")]
		public int TotalMeleeKills { get; set; }

		[JsonProperty("TotalMeleeDamage")]
		public double TotalMeleeDamage { get; set; }

		[JsonProperty("TotalAssassinations")]
		public int TotalAssassinations { get; set; }

		[JsonProperty("TotalGroundPoundKills")]
		public int TotalGroundPoundKills { get; set; }

		[JsonProperty("TotalGroundPoundDamage")]
		public double TotalGroundPoundDamage { get; set; }

		[JsonProperty("TotalShoulderBashKills")]
		public int TotalShoulderBashKills { get; set; }

		[JsonProperty("TotalShoulderBashDamage")]
		public double TotalShoulderBashDamage { get; set; }

		[JsonProperty("TotalGrenadeDamage")]
		public double TotalGrenadeDamage { get; set; }

		[JsonProperty("TotalPowerWeaponKills")]
		public int TotalPowerWeaponKills { get; set; }

		[JsonProperty("TotalPowerWeaponDamage")]
		public double TotalPowerWeaponDamage { get; set; }

		[JsonProperty("TotalPowerWeaponGrabs")]
		public int TotalPowerWeaponGrabs { get; set; }

		[JsonProperty("TotalPowerWeaponPossessionTime")]
		public string TotalPowerWeaponPossessionTime { get; set; }

		[JsonProperty("TotalDeaths")]
		public int TotalDeaths { get; set; }

		[JsonProperty("TotalAssists")]
		public int TotalAssists { get; set; }

		[JsonProperty("TotalGamesCompleted")]
		public int TotalGamesCompleted { get; set; }

		[JsonProperty("TotalGamesWon")]
		public int TotalGamesWon { get; set; }

		[JsonProperty("TotalGamesLost")]
		public int TotalGamesLost { get; set; }

		[JsonProperty("TotalGamesTied")]
		public int TotalGamesTied { get; set; }

		[JsonProperty("TotalTimePlayed")]
		public string TotalTimePlayed { get; set; }

		[JsonProperty("TotalGrenadeKills")]
		public int TotalGrenadeKills { get; set; }

		[JsonProperty("MedalAwards")]
		public IReadOnlyCollection<MedalStatistic> MedalAwards { get; set; }

		[JsonProperty("DestroyedEnemyVehicles")]
		public IReadOnlyCollection<EnemyKillsStatistic> DestroyedEnemyVehicles { get; set; }

		[JsonProperty("EnemyKills")]
		public IReadOnlyCollection<EnemyKillsStatistic> EnemyKills { get; set; }

		[JsonProperty("WeaponStats")]
		public IReadOnlyCollection<WeaponStatistic> WeaponStats { get; set; }

		[JsonProperty("Impulses")]
		public IReadOnlyCollection<ImpulseStatistic> Impulses { get; set; }

		[JsonProperty("TotalSpartanKills")]
		public int TotalSpartanKills { get; set; }
	}
}