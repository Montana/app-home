using System;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;
using Branch.Service.XboxLive.Database;
using Branch.Service.XboxLive.DocumentDb;
using Branch.Service.Xuid.Services;

namespace Branch.Service.XboxLive.Services
{
	public abstract class ServiceBase<T>
	{
		public ServiceBase(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			XuidLookupService xuidLookupService,
			XboxLiveDbContext xboxLiveDbContext, XboxLiveDdbRepository xboxLiveDdbRepository,
			AuthenticationService authenticationService)
		{
			HttpManagerService = httpManagerService;
			XuidLookupService = xuidLookupService;
			XboxLiveDbContext = xboxLiveDbContext;
			XboxLiveDdbRepository = xboxLiveDdbRepository;
			AuthenticationService = authenticationService;
			ServiceType = typeof(T);
			Logger = loggerFactory.CreateLogger<T>();
			Logger.LogVerbose($"Service Registered");
		}
		
		internal Type ServiceType { get; private set; }

		internal ILogger Logger { get; private set; }

		internal HttpManagerService HttpManagerService { get; private set; }

		internal XuidLookupService XuidLookupService { get; private set; }

		internal XboxLiveDbContext XboxLiveDbContext { get; private set; }

		internal XboxLiveDdbRepository XboxLiveDdbRepository { get; private set; }

		internal AuthenticationService AuthenticationService { get; private set; }
	}
}
