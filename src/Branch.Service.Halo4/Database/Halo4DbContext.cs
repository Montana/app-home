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
				.HasMany<GameHistory>(sr => sr.GameHistories)
				.WithOne(gh => gh.ServiceRecord)
				.ForeignKey(gh => gh.ServiceRecordId);
		}

		public DbSet<Authentication> Authentications { get; set; }

		public DbSet<ServiceRecord> ServiceRecords { get; set; }

		public DbSet<GameHistory> GameHistories { get; set; }
	}
}
