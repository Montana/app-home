using System;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;

namespace Branch.Game.Halo4.Services
{
	public abstract class ServiceBase
	{
		public ServiceBase(HttpManagerService httpManagerService,
			AuthenticationService authenticationService)
		{
			AuthenticationService = authenticationService;
			HttpManagerService = httpManagerService;
		}
		
		internal Type ServiceType { get; private set; }

		internal ILogger _logger { get; private set; }

		internal AuthenticationService AuthenticationService { get; private set; }

		internal HttpManagerService HttpManagerService { get; private set; }

		internal void RegisterService<T>(ILoggerFactory loggerFactory)
		{
			ServiceType = typeof(T);
			_logger = loggerFactory.CreateLogger<T>();
			_logger.LogVerbose($"[{ServiceType.FullName}] Service Registered");
		}
	}
}
