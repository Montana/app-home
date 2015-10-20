using Branch.Service.Halo4.Database;
using Branch.Service.Halo4.Services;
using Branch.Helpers.Services;
using Branch.Service.Halo4.Database.Repositories;
using Branch.Service.Halo4.DocumentDb;
using Branch.Service.Halo4.Database.Repositories.Interfaces;

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
			services.AddScoped<IMetadataRepository, MetadataRepository>();

			// Add Halo 4 Services
			services.AddSingleton<MetadataRepository>();
			services.AddSingleton<AuthenticationService>();
			services.AddSingleton<ServiceRecordService>();
			services.AddSingleton<MatchHistoryService>();
			services.AddSingleton<MetadataService>();

			return services;
		}
	}
}
