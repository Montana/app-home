using Branch.Service.Halo5.Database;
using Branch.Service.Halo5.Services;
using Branch.Helpers.Services;
using Branch.Service.Halo5.Database.Repositories;
using Branch.Service.Halo5.DocumentDb;
using Branch.Service.Halo5.Database.Repositories.Interfaces;

namespace Microsoft.Framework.DependencyInjection
{
	public static class ServiceCollectionExtentions
	{
		public static IServiceCollection AddHalo5(this IServiceCollection services)
		{
			// Add Helper Services
			services.AddTransient<HttpManagerService>();

			// Add Halo 5 Data Services
			services.AddSingleton<Halo5DbContext>();
			services.AddSingleton<Halo5DdbRepository>();
			services.AddEntityFramework().AddDbContext<Halo5DbContext>();
			
			// Add Halo 5 Database Repositories
			services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
			services.AddScoped<IServiceRecordRepository, ServiceRecordRepository>();
			services.AddScoped<IMatchHistoryRepository, MatchHistoryRepository>();
			services.AddScoped<IProfileAssetRepository, ProfileAssetRepository>();
			services.AddScoped<IMapVariantRepository, MapVariantRepository>();
			services.AddScoped<IGameVariantRepository, GameVariantRepository>();

			// Add Halo 5 Services
			services.AddSingleton<AuthenticationService>();
			services.AddSingleton<ServiceRecordService>();
			services.AddSingleton<MatchHistoryService>();
			services.AddSingleton<ProfileService>();
			services.AddSingleton<MetadataService>();

			return services;
		}
	}
}
