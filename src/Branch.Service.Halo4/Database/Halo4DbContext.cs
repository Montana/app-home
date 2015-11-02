using Branch.Helpers.Database;
using Branch.Helpers.Extentions;
using Branch.Service.Halo4.Database.Models;
using Microsoft.Data.Entity;
using Microsoft.Framework.Configuration;

namespace Branch.Service.Halo4.Database
{
	public class Halo4DbContext
		: AuditDatabaseContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(Startup.Configuration.GetDefaultOrBackup().Get<string>("Halo4:EntityFramework:ConnectionString"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ServiceRecord>()
				.HasMany(sr => sr.GameHistories)
				.WithOne(gh => gh.ServiceRecord)
				.ForeignKey(gh => gh.ServiceRecordId);

			modelBuilder.Entity<ServiceRecord>()
				.HasOne(sr => sr.Commendations)
				.WithOne(c => c.ServiceRecord)
				.ForeignKey<ServiceRecord>(sr => sr.CommendationsId);
		}

		public DbSet<Authentication> Authentications { get; set; }

		public DbSet<ServiceRecord> ServiceRecords { get; set; }

		public DbSet<GameHistory> GameHistories { get; set; }

		public DbSet<Commendations> Commendations { get; set; }

		public DbSet<Metadata> Metadata { get; set; }
	}
}
