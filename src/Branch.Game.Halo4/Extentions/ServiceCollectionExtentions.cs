using System;
using Branch.Game.Halo4.Database;
using Branch.Game.Halo4.Services;
using Branch.Helpers.Services;
using Branch.Service.Halo4.Database.Repositories;
using Microsoft.Data.Entity;

namespace Microsoft.Framework.DependencyInjection
{
	public static class ServiceCollectionExtentions
	{
		public static IServiceCollection AddHalo4(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
		{
			services.AddTransient<HttpManagerService>();
			services.AddTransient<Halo4Context>();
			services.AddScoped<AuthenticationRepository>();
			services.AddSingleton<AuthenticationService>();
			services.AddSingleton<ProfileService>();
			services.AddEntityFramework().AddDbContext<Halo4Context>(options);

			return services;
		}
	}
}
