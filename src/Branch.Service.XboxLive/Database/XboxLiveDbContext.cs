using Branch.Helpers.Database;
using Branch.Helpers.Extentions;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace Branch.Service.XboxLive.Database
{
	public class XboxLiveDbContext
		: AuditDatabaseContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(Startup.Configuration.GetDefaultOrBackup().Get<string>("XboxLive:EntityFramework:ConnectionString"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}
