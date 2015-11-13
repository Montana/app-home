using System;
using Branch.Service.Halo5.Database;
using Branch.Helpers.Services;
using Branch.Service.Halo5.DocumentDb;
using Microsoft.Framework.Logging;
using Branch.Service.Xuid.Services;

namespace Branch.Service.Halo5.Services
{
	public abstract class ServiceBase<T>
	{
		public ServiceBase(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			XuidLookupService xuidLookupService, Halo5DbContext halo5DbContext, Halo5DdbRepository halo5DdbRepository,
			AuthenticationService authenticationService)
		{
			HttpManagerService = httpManagerService;
			XuidLookupService = xuidLookupService;
			Halo5DbContext = halo5DbContext;
			Halo5DdbRepository = halo5DdbRepository;
			AuthenticationService = authenticationService;
			ServiceType = typeof(T);
			Logger = loggerFactory.CreateLogger<T>();
			Logger.LogVerbose($"Service Registered");
		}
		
		internal Type ServiceType { get; private set; }

		internal ILogger Logger { get; private set; }

		internal HttpManagerService HttpManagerService { get; private set; }

		internal XuidLookupService XuidLookupService { get; private set; }

		internal Halo5DbContext Halo5DbContext { get; private set; }

		internal Halo5DdbRepository Halo5DdbRepository { get; private set; }

		internal AuthenticationService AuthenticationService { get; private set; }
	}
}
