﻿using Branch.Helpers.Services;
using Branch.Service.Xuid.Database;
using Branch.Service.Xuid.Database.Repositories;
using Branch.Service.Xuid.Database.Repositories.Interfaces;
using Branch.Service.Xuid.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Framework.DependencyInjection
{
	public static class ServiceCollectionExtentions
	{
		public static IServiceCollection AddXuid(this IServiceCollection services)
		{
			// Add Helper Services
			services.AddTransient<HttpManagerService>();

			// Add Xbox Live Data Services
			services.AddScoped<XuidDbContext>();
			services.AddEntityFramework().AddDbContext<XuidDbContext>();

			// Add Xbox Live Database Repositories
			services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
			services.AddScoped<IXuidCacheRepository, XuidCacheRepository>();

			// Add Xbox Live Services
			services.AddSingleton<AuthenticationService>();
			services.AddSingleton<XuidLookupService>();

			return services;
		}
	}
}
