using Branch.Game.Halo4.Database;
using Branch.Game.Halo4.Services;
using Branch.Helpers.Services;
using Branch.Game.Halo4.Database.Repositories;
using Branch.Game.Halo4.DocumentDb;
using Branch.Game.Halo4.Database.Repositories.Interfaces;

namespace Microsoft.Framework.DependencyInjection
{
	public static class ServiceCollectionExtentions
	{
		public static IServiceCollection AddHalo4(this IServiceCollection services)
		{
			services.AddTransient<HttpManagerService>();
			services.AddTransient<Halo4DbContext>();
			services.AddTransient<Halo4DdbRepository>();
			services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
			services.AddScoped<IServiceRecordRepository, ServiceRecordRepository>();
			services.AddSingleton<AuthenticationService>();
			services.AddSingleton<ServiceRecordService>();
			services.AddEntityFramework().AddDbContext<Halo4DbContext>();

			return services;
		}
	}
}
