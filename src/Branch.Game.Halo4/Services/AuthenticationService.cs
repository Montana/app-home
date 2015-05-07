using Branch.Game.Halo4.Models.Services;
using Branch.Game.Halo4.Database;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using Branch.Helpers.Services;
using Branch.Service.Halo4.Database.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System;
using Branch.Service.Halo4.Models.Auth;
using Branch.Service.Halo4.Database.Models;

namespace Branch.Game.Halo4.Services
{
	public class AuthenticationService
	{
		public AuthenticationService(Halo4Context halo4Context, AuthenticationRepository authenticationRepository, HttpManagerService httpManagerService)
		{
			_halo4Context = halo4Context;
			_authenticationRepository = authenticationRepository;
			_httpManagerService = httpManagerService;
		}

		private Type ServiceType { get; set; }

		private Halo4Context _halo4Context { get; set; }

		private AuthenticationRepository _authenticationRepository { get; set; }

		private HttpManagerService _httpManagerService { get; set; }

		private Halo4AuthenticationOptions _options { get; set; }
		
		private ILogger _logger { get; set; }
		
		internal void RegisterService<T>(ILoggerFactory loggerFactory, Halo4AuthenticationOptions options)
		{
			ServiceType = typeof(T);
			_options = options;
			_logger = loggerFactory.CreateLogger<T>();
			_logger.LogInformation($"[{ServiceType.FullName}] Service Registered");
		}

		public async Task<string> GetSpartanTokenAsync()
		{
			_logger.LogVerbose($"[{ServiceType.FullName}] Entered GetToken");

			var authentication = (await _authenticationRepository.GetAllAsync()).FirstOrDefault();
			_logger.LogVerbose($"[{ServiceType.FullName}] Retrieved Authentication from Database");

			if (authentication != null && authentication.ExpiresAt > DateTime.UtcNow)
			{
				_logger.LogVerbose($"[{ServiceType.FullName}] Using existing SpartanToken - ${authentication.SpartanToken}");
				return authentication.SpartanToken;
			}

			var x = await _httpManagerService.ExecuteRequestAsync<Response>(HttpMethod.POST,
				new Uri(_options.ApiEndpoint), payload: new Request
				{
					MicrosoftAccount = _options.MicrosoftAccount,
					MicrosoftAccountPassword = _options.MicrosoftAccountPassword
				});

			if (authentication == null)
				authentication = new Authentication();
			authentication.AnalyticsToken = x.Result.AnalyticsToken;
			authentication.Gamertag = x.Result.Gamertag;
			authentication.SpartanToken = x.Result.SpartanToken;
			authentication.ExpiresAt = DateTime.UtcNow.AddMinutes(55);
			await _authenticationRepository.UpdateAsync(authentication);

			return authentication.SpartanToken;
		}
	}
}
