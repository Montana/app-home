using Branch.Helpers.Database;
using Branch.Game.Halo4.Database.Models;
using Microsoft.Data.Entity;
using Branch.Helpers.Configuration;

namespace Branch.Game.Halo4.Database
{
	public class Halo4DbContext
		: AuditDatabaseContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConfigurationLoader.Retrieve().Get("Halo4:EntityFramework:ConnectionString"));
		}

		public DbSet<Authentication> Authentications { get; set; }

		public DbSet<ServiceRecord> ServiceRecords { get; set; }
	}
}
