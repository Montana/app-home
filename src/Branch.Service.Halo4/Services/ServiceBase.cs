using System;
using Branch.Service.Halo4.Database;
using Branch.Helpers.Services;
using Branch.Service.Halo4.DocumentDb;
using Microsoft.Framework.Logging;

namespace Branch.Service.Halo4.Services
{
	public abstract class ServiceBase<T>
	{
		public ServiceBase(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			Halo4DbContext halo4DbContext, Halo4DdbRepository halo4DdbRepository,
			AuthenticationService authenticationService)
		{
			HttpManagerService = httpManagerService;
			Halo4DbContext = halo4DbContext;
			Halo4DdbRepository = halo4DdbRepository;
			AuthenticationService = authenticationService;
			ServiceType = typeof(T);
			Logger = loggerFactory.CreateLogger<T>();
			Logger.LogVerbose($"Service Registered");
		}
		
		internal Type ServiceType { get; private set; }

		internal ILogger Logger { get; private set; }

		internal HttpManagerService HttpManagerService { get; private set; }

		internal Halo4DbContext Halo4DbContext { get; private set; }

		internal Halo4DdbRepository Halo4DdbRepository { get; private set; }

		internal AuthenticationService AuthenticationService { get; private set; }
	}
}
