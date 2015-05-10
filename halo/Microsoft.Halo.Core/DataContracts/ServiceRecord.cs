using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.Halo.Core.DataContracts.Abstracts;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class ServiceRecord
		: Response
	{
		[DataMember(Name = "DateFidelity")]
		public int DateFidelity { get; set; }

		[DataMember(Name = "LastPlayedUtc")]
		public DateTime LastPlayedUtc { get; set; }

		[DataMember(Name = "FirstPlayedUtc")]
		public DateTime FirstPlayedUtc { get; set; }

		[DataMember(Name = "SpartanPoints")]
		public uint SpartanPoints { get; set; }

		[DataMember(Name = "TotalGamesStarted")]
		public uint TotalGamesStarted { get; set; }

		[DataMember(Name = "TotalMedalsEarned")]
		public uint TotalMedalsEarned { get; set; }

		[DataMember(Name = "TotalGameplay")]
		public TimeSpan TotalGameplay { get; set; }

		[DataMember(Name = "TotalChallengesCompleted")]
		public uint TotalChallengesCompleted { get; set; }

		[DataMember(Name = "Promotions")]
		public IReadOnlyCollection<Promotion> Promotions { get; set; }

		[DataMember(Name = "TotalLoadoutItemsPurchased")]
		public uint TotalLoadoutItemsPurchased { get; set; }

		[DataMember(Name = "TotalCommendationProgress")]
		public decimal TotalCommendationProgress { get; set; }

		[DataMember(Name = "SkillRanks")]
		public IReadOnlyCollection<SkillRank> SkillRanks { get; set; }

		[DataMember(Name = "Gamertag")]
		public string Gamertag { get; set; }

		[DataMember(Name = "ServiceTag")]
		public string ServiceTag { get; set; }

		[DataMember(Name = "EmblemImageUrl")]
		public AssetContainer EmblemImageUrl { get; set; }

		[DataMember(Name = "BackgroundImageUrl")]
		public AssetContainer BackgroundImageUrl { get; set; }

		[DataMember(Name = "FavoriteWeaponId")]
		public uint FavoriteWeaponId { get; set; }

		[DataMember(Name = "FavoriteWeaponName")]
		public string FavoriteWeaponName { get; set; }

		[DataMember(Name = "FavoriteWeaponDescription")]
		public string FavoriteWeaponDescription { get; set; }

		[DataMember(Name = "FavoriteWeaponImageUrl")]
		public AssetContainer FavoriteWeaponImageUrl { get; set; }

		[DataMember(Name = "FavoriteWeaponTotalKills")]
		public uint FavoriteWeaponTotalKills { get; set; }

		[DataMember(Name = "RankId")]
		public uint RankId { get; set; }

		[DataMember(Name = "RankName")]
		public string RankName { get; set; }

		[DataMember(Name = "RankImageUrl")]
		public AssetContainer RankImageUrl { get; set; }

		[DataMember(Name = "RankStartXP")]
		public uint RankStartXP { get; set; }

		[DataMember(Name = "NextRankStartXP")]
		public ulong NextRankStartXP { get; set; }

		[DataMember(Name = "XP")]
		public uint Xp { get; set; }

		[DataMember(Name = "NextRankId")]
		public uint NextRankId { get; set; }

		[DataMember(Name = "NextRankName")]
		public string NextRankName { get; set; }

		[DataMember(Name = "NextRankImageUrl")]
		public AssetContainer NextRankImageUrl { get; set; }

		[DataMember(Name = "TopMedals")]
		public IReadOnlyCollection<Medal> TopMedals { get; set; }

		[DataMember(Name = "Specializations")]
		public IReadOnlyCollection<Specialization> Specializations { get; set; }

		[DataMember(Name = "GameModes")]
		public IReadOnlyCollection<GameModeDetailsFull> GameModes { get; set; }

		[DataMember(Name = "TopSkillRank")]
		public SkillRank TopSkillRank { get; set; }
	}
}
