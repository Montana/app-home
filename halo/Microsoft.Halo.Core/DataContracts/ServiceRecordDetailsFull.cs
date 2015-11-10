using System;
using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{

	public class ServiceRecordDetailsFull
		: Response
	{
		[JsonProperty("DateFidelity")]
		public int DateFidelity { get; set; }

		[JsonProperty("LastPlayedUtc")]
		public DateTime LastPlayedUtc { get; set; }

		[JsonProperty("FirstPlayedUtc")]
		public DateTime FirstPlayedUtc { get; set; }

		[JsonProperty("SpartanPoints")]
		public uint SpartanPoints { get; set; }

		[JsonProperty("TotalGamesStarted")]
		public uint TotalGamesStarted { get; set; }

		[JsonProperty("TotalMedalsEarned")]
		public uint TotalMedalsEarned { get; set; }

		[JsonProperty("TotalGameplay")]
		public TimeSpan TotalGameplay { get; set; }

		[JsonProperty("TotalChallengesCompleted")]
		public uint TotalChallengesCompleted { get; set; }

		[JsonProperty("Promotions")]
		public IReadOnlyCollection<PromotionDetailsFull> Promotions { get; set; }

		[JsonProperty("TotalLoadoutItemsPurchased")]
		public uint TotalLoadoutItemsPurchased { get; set; }

		[JsonProperty("TotalCommendationProgress")]
		public decimal TotalCommendationProgress { get; set; }

		[JsonProperty("SkillRanks")]
		public IReadOnlyCollection<SkillRankDetailsFull> SkillRanks { get; set; }

		[JsonProperty("Gamertag")]
		public string Gamertag { get; set; }

		[JsonProperty("Xuid")]
		public Int64 Xuid { get; set; }

		[JsonProperty("ServiceTag")]
		public string ServiceTag { get; set; }

		[JsonProperty("EmblemImageUrl")]
		public AssetContainer EmblemImageUrl { get; set; }

		[JsonProperty("BackgroundImageUrl")]
		public AssetContainer BackgroundImageUrl { get; set; }

		[JsonProperty("FavoriteWeaponId")]
		public uint FavoriteWeaponId { get; set; }

		[JsonProperty("FavoriteWeaponName")]
		public string FavoriteWeaponName { get; set; }

		[JsonProperty("FavoriteWeaponDescription")]
		public string FavoriteWeaponDescription { get; set; }

		[JsonProperty("FavoriteWeaponImageUrl")]
		public AssetContainer FavoriteWeaponImageUrl { get; set; }

		[JsonProperty("FavoriteWeaponTotalKills")]
		public uint FavoriteWeaponTotalKills { get; set; }

		[JsonProperty("RankId")]
		public uint RankId { get; set; }

		[JsonProperty("RankName")]
		public string RankName { get; set; }

		[JsonProperty("RankImageUrl")]
		public AssetContainer RankImageUrl { get; set; }

		[JsonProperty("RankStartXP")]
		public uint RankStartXp { get; set; }

		[JsonProperty("NextRankStartXP")]
		public ulong NextRankStartXp { get; set; }

		[JsonProperty("XP")]
		public uint Xp { get; set; }

		[JsonProperty("NextRankId")]
		public uint NextRankId { get; set; }

		[JsonProperty("NextRankName")]
		public string NextRankName { get; set; }

		[JsonProperty("NextRankImageUrl")]
		public AssetContainer NextRankImageUrl { get; set; }

		[JsonProperty("TopMedals")]
		public IReadOnlyCollection<MedalDetails> TopMedals { get; set; }

		[JsonProperty("Specializations")]
		public IReadOnlyCollection<SpecializationDetailsPartial> Specializations { get; set; }

		[JsonProperty("GameModes")]
		public IReadOnlyCollection<GameModeDetailsFull> GameModes { get; set; }

		[JsonProperty("TopSkillRank")]
		public SkillRankDetailsFull TopSkillRank { get; set; }
	}
}
