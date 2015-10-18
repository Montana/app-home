using System;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;
using Branch.Service.Xuid.Database;

namespace Branch.Service.Xuid.Services
{
	public abstract class ServiceBase<T>
	{
		public ServiceBase(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			XuidDbContext xuidDbContext, AuthenticationService authenticationService)
		{
			HttpManagerService = httpManagerService;
			XboxLiveDbContext = xuidDbContext;
			AuthenticationService = authenticationService;
			ServiceType = typeof(T);
			Logger = loggerFactory.CreateLogger<T>();
			Logger.LogVerbose($"Service Registered");
		}
		
		internal Type ServiceType { get; private set; }

		internal ILogger Logger { get; private set; }

		internal HttpManagerService HttpManagerService { get; private set; }

		internal XuidDbContext XboxLiveDbContext { get; private set; }
		
		internal AuthenticationService AuthenticationService { get; private set; }
	}
}
