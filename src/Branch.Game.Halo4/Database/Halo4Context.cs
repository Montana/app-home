using Branch.Helpers.Database;
using Branch.Service.Halo4.Database.Models;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;

namespace Branch.Game.Halo4.Database
{
	public class Halo4Context
		: AuditDatabaseContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var configuration = new Configuration();
			configuration.AddUserSecrets();
			configuration.AddEnvironmentVariables();

			optionsBuilder.UseSqlServer(configuration.Get("EntityFramework:Halo4Context:ConnectionString"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{


			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Authentication> Authentications { get; set; }
	}
}
