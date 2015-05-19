using Branch.Helpers.Database;
using Branch.Service.Halo4.Database.Models;
using Microsoft.Data.Entity;
using Branch.Helpers.Configuration;

namespace Branch.Service.Halo4.Database
{
	public class Halo4DbContext
		: AuditDatabaseContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConfigurationLoader.Retrieve().Get("Halo4:EntityFramework:ConnectionString"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ServiceRecord>()
				.Collection<GameHistory>(sr => sr.GameHistories)
				.InverseReference(gh => gh.ServiceRecord)
				.ForeignKey(gh => gh.ServiceRecordId);
		}

		public DbSet<Authentication> Authentications { get; set; }

		public DbSet<ServiceRecord> ServiceRecords { get; set; }

		public DbSet<GameHistory> GameHistories { get; set; }
	}
}
