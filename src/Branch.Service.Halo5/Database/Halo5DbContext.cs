using Branch.Helpers.Database;
using Branch.Helpers.Extentions;
using Branch.Service.Halo5.Database.Models;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace Branch.Service.Halo5.Database
{
	public class Halo5DbContext
		: AuditDatabaseContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(Startup.Configuration.GetDefaultOrBackup().Get<string>("Halo5:EntityFramework:ConnectionString"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ServiceRecord>()
				.HasOne(sr => sr.Player)
				.WithMany(p => p.ServiceRecords)
				.HasForeignKey(sr => sr.PlayerId);
		}

		public DbSet<Authentication> Authentications { get; set; }

		public DbSet<Player> Players { get; set; }

		public DbSet<ServiceRecord> ServiceRecords { get; set; }

		public DbSet<MatchHistory> MatchHistories { get; set; }

		public DbSet<ProfileAsset> ProfileAssets { get; set; }

		public DbSet<MapVariant> MapVariants { get; set; }

		public DbSet<GameVariant> GameVariants { get; set; }
	}
}
