using Microsoft.Extensions.Logging;
using Branch.Helpers.Services;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using Branch.Helpers.Extentions;
using Branch.Service.Xuid.Database;
using Branch.Service.Xuid.Database.Repositories.Interfaces;
using Branch.Service.Xuid.Database.Models;
using Branch.Service.Xuid.Models.Services;
using Branch.Service.Xuid.Models.Auth;

namespace Branch.Service.Xuid.Services
{
	public class AuthenticationService
	{
		public AuthenticationService(ILoggerFactory x, XuidDbContext xuidDbContext, IAuthenticationRepository authenticationRepository, HttpManagerService httpManagerService)
		{
			_serviceType = typeof(AuthenticationService);
			_xuidDbContext = xuidDbContext;
			_authenticationRepository = authenticationRepository;
			_httpManagerService = httpManagerService;
			_logger = x.CreateLogger<AuthenticationService>();
			_logger.LogInformation($"Service Registered");

			var config = Startup.Configuration.GetDefaultOrBackup();
			_options = new XboxLiveAuthenticationOptions
			{
				MicrosoftAccount = config.Get<string>("Xuid:Authentication:MicrosoftAccount"),
				MicrosoftAccountPassword = config.Get<string>("Xuid:Authentication:MicrosoftAccountPassword"),
				ApiEndpoint = config.Get<string>("Xuid:Authentication:ApiEndpoint")
			};
		}

		private Type _serviceType { get; set; }

		private XuidDbContext _xuidDbContext { get; set; }

		private IAuthenticationRepository _authenticationRepository { get; set; }

		private HttpManagerService _httpManagerService { get; set; }

		private XboxLiveAuthenticationOptions _options { get; set; }

		private ILogger _logger { get; set; }

		public async Task<Authentication> GetAuthenticationAsync()
		{
			_logger.LogVerbose($"Entered GetToken");

			var authentication = _authenticationRepository.GetAll().FirstOrDefault();
			_logger.LogVerbose($"Retrieved Authentication from Database");

			if (authentication != null)
			{
				if (authentication.Token == null)
				{
					_logger.LogVerbose($"No valid authentication exists");
					return null;
				}

				if (authentication.ExpiresAt > DateTime.UtcNow)
				{
					_logger.LogVerbose($"Using existing Token - ${authentication.Token}");
					return authentication;
				}
			}

			var windowsLiveToken = await _httpManagerService.ExecuteRequestAsync<Response>(HttpMethod.POST,
				new Uri(_options.ApiEndpoint), payload: new WindowsLiveRequest
				{
					MicrosoftAccount = _options.MicrosoftAccount,
					MicrosoftAccountPassword = _options.MicrosoftAccountPassword
				});

			var xboxLiveAuthentication = await _httpManagerService.ExecuteRequestAsync<XboxLiveAuthenticateResponse>(HttpMethod.POST,
				new Uri("https://user.auth.xboxlive.com/user/authenticate"), payload: new XboxLiveAuthenticateRequest
				{
					Properties = new XboxLiveAuthenticateProperties
					{
						AuthMethod = "RPS",
						RpsTicket = $"t={windowsLiveToken.Result.Token}",
						SiteName = "user.auth.xboxlive.com"
					},
					RelyingParty = "http://auth.xboxlive.com",
					TokenType = "JWT"
				});

			var xboxLiveAuthorization = await _httpManagerService.ExecuteRequestAsync<XboxLiveAuthorizeResponse>(HttpMethod.POST,
				new Uri("https://xsts.auth.xboxlive.com/xsts/authorize"), payload: new XboxLiveAuthorizeRequest
				{
					Properties = new XboxLiveAuthorizeProperties
					{
						SandboxId = "RETAIL",
						UserTokens = new[] { xboxLiveAuthentication.Token }
					},
					RelyingParty = "http://xboxlive.com",
					TokenType = "JWT"
				});

			if (authentication == null)
				authentication = new Authentication();
			authentication.ExpiresAt = DateTime.UtcNow.AddMinutes(55);
			authentication.Gamertag = xboxLiveAuthorization.DisplayClaims["xui"][0]["gtg"];
			authentication.Token = xboxLiveAuthorization.Token;
			authentication.UserHash = xboxLiveAuthentication.DisplayClaims["xui"][0]["uhs"];
			authentication.Xuid = Int64.Parse(xboxLiveAuthorization.DisplayClaims["xui"][0]["xid"].ToString());
			authentication = _authenticationRepository.Update(authentication);

			return authentication;
		}

		public async Task<string> GetTokenAsync()
		{
			return (await GetAuthenticationAsync()).Token;
		}
	}
}
