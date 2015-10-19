using System;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;
using Branch.Service.Xuid.Database;
using Branch.Service.Xuid.Database.Repositories.Interfaces;

namespace Branch.Service.Xuid.Services
{
	public abstract class ServiceBase<T>
	{
		public ServiceBase(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			XuidDbContext xuidDbContext, IXuidCacheRepository xuidCacheRepository,
			AuthenticationService authenticationService)
		{
			HttpManagerService = httpManagerService;
			XuidDbContext = xuidDbContext;
			XuidCacheRepository = xuidCacheRepository;
			AuthenticationService = authenticationService;
			ServiceType = typeof(T);
			Logger = loggerFactory.CreateLogger<T>();
			Logger.LogVerbose($"Service Registered");
		}

		internal Type ServiceType { get; private set; }

		internal ILogger Logger { get; private set; }

		internal HttpManagerService HttpManagerService { get; private set; }

		internal XuidDbContext XuidDbContext { get; private set; }

		internal IXuidCacheRepository XuidCacheRepository { get; private set; }

		internal AuthenticationService AuthenticationService { get; private set; }
	}
}
