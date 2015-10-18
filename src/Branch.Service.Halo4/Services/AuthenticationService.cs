using Branch.Service.Halo4.Models.Services;
using Branch.Service.Halo4.Database;
using Microsoft.Framework.Logging;
using Branch.Helpers.Services;
using System.Linq;
using System.Threading.Tasks;
using System;
using Branch.Service.Halo4.Models.Auth;
using Branch.Service.Halo4.Database.Models;
using Branch.Service.Halo4.Database.Repositories.Interfaces;
using Microsoft.Framework.Configuration;

namespace Branch.Service.Halo4.Services
{
	public class AuthenticationService
	{
		public AuthenticationService(ILoggerFactory x, Halo4DbContext halo4DbContext, IAuthenticationRepository authenticationRepository, HttpManagerService httpManagerService)
		{
			_serviceType = typeof(AuthenticationService);
			_halo4DbContext = halo4DbContext;
			_authenticationRepository = authenticationRepository;
			_httpManagerService = httpManagerService;
			_logger = x.CreateLogger<AuthenticationService>();
			_logger.LogInformation($"Service Registered");

			var config = Startup.Configuration;
			_options = new Halo4AuthenticationOptions
			{
				MicrosoftAccount = config.Get<string>("Halo4:Authentication:MicrosoftAccount"),
				MicrosoftAccountPassword = config.Get<string>("Halo4:Authentication:MicrosoftAccountPassword"),
				ApiEndpoint = config.Get<string>("Halo4:Authentication:ApiEndpoint")
			};
		}

		private Type _serviceType { get; set; }

		private Halo4DbContext _halo4DbContext { get; set; }

		private IAuthenticationRepository _authenticationRepository { get; set; }

		private HttpManagerService _httpManagerService { get; set; }

		private Halo4AuthenticationOptions _options { get; set; }

		private ILogger _logger { get; set; }

		public async Task<Authentication> GetAuthenticationAsync()
		{
			_logger.LogVerbose($"Entered GetToken");

			var authentication = _authenticationRepository.GetAll().FirstOrDefault();
			_logger.LogVerbose($"Retrieved Authentication from Database");

			if (authentication != null)
			{
				if (authentication.SpartanToken == null)
				{
					_logger.LogVerbose($"No valid authentication exists");
					return null;
				}

				if (authentication.ExpiresAt > DateTime.UtcNow)
				{
					_logger.LogVerbose($"Using existing SpartanToken - ${authentication.SpartanToken}");
					return authentication;
				}
			}

			var x = await _httpManagerService.ExecuteRequestAsync<Response>(HttpMethod.POST,
				new Uri(_options.ApiEndpoint), payload: new Request
				{
					MicrosoftAccount = _options.MicrosoftAccount,
					MicrosoftAccountPassword = _options.MicrosoftAccountPassword
				});
			
			if (x == null)
				return null;// TODO: handle failure, and alert owner
			
			if (authentication == null)
				authentication = new Authentication();
			authentication.AnalyticsToken = x.Result.AnalyticsToken;
			authentication.Gamertag = x.Result.Gamertag;
			authentication.SpartanToken = x.Result.SpartanToken;
			authentication.ExpiresAt = DateTime.UtcNow.AddMinutes(55);
			_authenticationRepository.Update(authentication);

			return authentication;
		}

		public async Task<string> GetAnalyticsTokenAsync()
		{
			var authentication = await GetAuthenticationAsync();
			return authentication?.AnalyticsToken;
		}

		public async Task<string> GetSpartanTokenAsync()
		{
			var authentication = await GetAuthenticationAsync();
			return authentication?.SpartanToken;
		}

		public async Task<DateTime> GetSpartanTokenExpirationAsync()
		{
			var authentication = await GetAuthenticationAsync();
			return authentication == null
				? new DateTime(1994, 08, 18)
				: authentication.ExpiresAt;
		}

		public async Task<string> GetGamertagAsync()
		{
			var authentication = await GetAuthenticationAsync();
			return authentication?.Gamertag;
		}
	}
}
