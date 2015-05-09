using System;
using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Abstracts;

namespace Microsoft.Halo.Core.DataContracts
{
	public class ServiceRecord
		: Response
	{
		public int DateFidelity { get; set; }

		public DateTime LastPlayedUtc { get; set; }

		public DateTime FirstPlayedUtc { get; set; }

		public uint SpartanPoints { get; set; }

		public uint TotalGamesStarted { get; set; }

		public uint TotalMedalsEarned { get; set; }

		public TimeSpan TotalGameplay { get; set; }

		public uint TotalChallengesCompleted { get; set; }

		public IReadOnlyCollection<Promotion> Promotions { get; set; }

		public uint TotalLoadoutItemsPurchased { get; set; }

		public decimal TotalCommendationProgress { get; set; }

		public IReadOnlyCollection<SkillRank> SkillRanks { get; set; }

		public string Gamertag { get; set; }

		public string ServiceTag { get; set; }

		public AssetContainer EmblemImageUrl { get; set; }

		public AssetContainer BackgroundImageUrl { get; set; }

		public uint FavoriteWeaponId { get; set; }

		public string FavoriteWeaponName { get; set; }

		public string FavoriteWeaponDescription { get; set; }

		public AssetContainer FavoriteWeaponImageUrl { get; set; }

		public uint FavoriteWeaponTotalKills { get; set; }

		public uint RankId { get; set; }

		public string RankName { get; set; }

		public AssetContainer RankImageUrl { get; set; }

		public uint RankStartXP { get; set; }

		public ulong NextRankStartXP { get; set; }

		public uint XP { get; set; }

		public uint NextRankId { get; set; }

		public string NextRankName { get; set; }

		public AssetContainer NextRankImageUrl { get; set; }

		public IReadOnlyCollection<Medal> TopMedals { get; set; }

		public IReadOnlyCollection<Specialization> Specializations { get; set; }

		public IReadOnlyCollection<GameModeDetailsFull> GameModes { get; set; }

		public SkillRank TopSkillRank { get; set; }
	}
}
