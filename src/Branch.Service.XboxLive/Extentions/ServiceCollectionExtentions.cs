using Branch.Helpers.Services;
using Branch.Service.Halo4.Database.Repositories;
using Branch.Service.XboxLive.Database;
using Branch.Service.XboxLive.Database.Repositories.Interfaces;
using Branch.Service.XboxLive.DocumentDb;
using Branch.Service.XboxLive.Services;

namespace Microsoft.Framework.DependencyInjection
{
	public static class ServiceCollectionExtentions
	{
		public static IServiceCollection AddXboxLive(this IServiceCollection services)
		{
			// Add Helper Services
			services.AddTransient<HttpManagerService>();

			//// Add Xbox Live Data Services
			services.AddScoped<XboxLiveDbContext>();
			services.AddScoped<XboxLiveDdbRepository>();
			services.AddEntityFramework().AddDbContext<XboxLiveDbContext>();

			// Add Xbox Live Database Repositories
			services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

			// Add Xbox Live Services
			services.AddSingleton<AuthenticationService>();
			services.AddSingleton<UserService>();
			services.AddSingleton<TitleHistoryService>();
			services.AddSingleton<EntertainmentDiscoveryService>();

			return services;
		}
	}
}
