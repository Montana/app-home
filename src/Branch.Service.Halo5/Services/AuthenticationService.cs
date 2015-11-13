using Branch.Service.Halo5.Database;
using Microsoft.Framework.Logging;
using Branch.Helpers.Services;
using System;
using Branch.Service.Halo5.Database.Repositories.Interfaces;
using Microsoft.Framework.Configuration;
using Branch.Helpers.Extentions;

namespace Branch.Service.Halo5.Services
{
	public class AuthenticationService
	{
		public AuthenticationService(ILoggerFactory x, Halo5DbContext halo5DbContext, IAuthenticationRepository authenticationRepository, HttpManagerService httpManagerService)
		{
			ServiceType = typeof(AuthenticationService);
			Halo5DbContext = halo5DbContext;
			AuthenticationRepository = authenticationRepository;
			HttpManagerService = httpManagerService;
			Logger = x.CreateLogger<AuthenticationService>();
			Logger.LogInformation($"Service Registered");

			var config = Startup.Configuration.GetDefaultOrBackup();
			Halo5AuthenticationKey = config.Get<string>("Halo5:AuthenticationKey");
		}

		private Type ServiceType { get; set; }

		private Halo5DbContext Halo5DbContext { get; set; }

		private string Halo5AuthenticationKey { get; }

		private IAuthenticationRepository AuthenticationRepository { get; set; }

		private HttpManagerService HttpManagerService { get; set; }
		
		private ILogger Logger { get; }

		public string GetAuthenticationAsync()
		{
			Logger.LogVerbose($"Entered GetAuthenticationAsync");
			
			return Halo5AuthenticationKey;
		}
	}
}
