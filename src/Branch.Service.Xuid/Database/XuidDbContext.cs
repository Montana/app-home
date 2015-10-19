using Branch.Helpers.Database;
using Branch.Helpers.Extentions;
using Branch.Service.Xuid.Database.Models;
using Microsoft.Data.Entity;
using Microsoft.Framework.Configuration;

namespace Branch.Service.Xuid.Database
{
	public class XuidDbContext
		: AuditDatabaseContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(Startup.Configuration.GetDefaultOrBackup().Get<string>("Xuid:EntityFramework:ConnectionString"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}

		public DbSet<Authentication> Authentications { get; set; }

		public DbSet<XuidCache> XuidCaches { get; set; }
	}
}
