using Branch.Helpers.Configuration;
using Branch.Helpers.Database;
using Branch.Service.XboxLive.Database.Models;
using Microsoft.Data.Entity;

namespace Branch.Service.XboxLive.Database
{
	public class XboxLiveDbContext
		: AuditDatabaseContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConfigurationLoader.Retrieve().Get("XboxLive:EntityFramework:ConnectionString"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}

		public DbSet<Authentication> Authentications { get; set; }
	}
}
