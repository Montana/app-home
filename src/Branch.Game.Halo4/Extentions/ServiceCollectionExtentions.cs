using Branch.Game.Halo4.Database;
using Branch.Game.Halo4.Services;
using Branch.Helpers.Services;
using Branch.Game.Halo4.Database.Repositories;
using Branch.Game.Halo4.DocumentDb;
using Branch.Game.Halo4.Database.Repositories.Interfaces;
using Branch.Game.Halo4.Expander;
using Microsoft.AspNet.FileSystems;

namespace Microsoft.Framework.DependencyInjection
{
	public static class ServiceCollectionExtentions
	{
		public static IServiceCollection AddHalo4(this IServiceCollection services)
		{
			// Add Helper Services
			services.AddTransient<HttpManagerService>();

			// Add Halo 4 Data Services
			services.AddSingleton<Halo4DbContext>();
			services.AddSingleton<Halo4DdbRepository>();
			services.AddEntityFramework().AddDbContext<Halo4DbContext>();
			
			// Add Halo 4 Database Repositories
			services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
			services.AddScoped<IServiceRecordRepository, ServiceRecordRepository>();
			services.AddScoped<IGameHistoryRepository, GameHistoryRepository>();

			// Add Halo 4 Services
			services.AddSingleton<AuthenticationService>();
			services.AddSingleton<ServiceRecordService>();
			services.AddSingleton<MatchHistoryService>();

			return services;
		}
	}
}
