using Branch.Helpers.Services;
using Branch.Service.Xuid.Database;
using Branch.Service.Xuid.Database.Repositories;
using Branch.Service.Xuid.Database.Repositories.Interfaces;
using Branch.Service.Xuid.Services;

namespace Microsoft.Framework.DependencyInjection
{
	public static class ServiceCollectionExtentions
	{
		public static IServiceCollection AddXuid(this IServiceCollection services)
		{
			// Add Helper Services
			services.AddTransient<HttpManagerService>();

			//// Add Xbox Live Data Services
			services.AddScoped<XuidDbContext>();
			services.AddEntityFramework().AddDbContext<XuidDbContext>();

			// Add Xbox Live Database Repositories
			services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

			// Add Xbox Live Services
			services.AddSingleton<AuthenticationService>();

			return services;
		}
	}
}
