using Microsoft.Framework.Logging;
using Branch.Helpers.Services;
using System.Linq;
using System.Threading.Tasks;
using System;
using Branch.Helpers.Configuration;
using Branch.Service.XboxLive.Database;
using Branch.Service.XboxLive.Models.Services;
using Branch.Service.XboxLive.Database.Models;
using Branch.Service.XboxLive.Database.Repositories.Interfaces;
using Branch.Service.XboxLive.Models.Auth;

namespace Branch.Service.XboxLive.Services
{
	public class AuthenticationService
	{
		public AuthenticationService(ILoggerFactory x, XboxLiveDbContext xboxLiveDbContext, IAuthenticationRepository authenticationRepository, HttpManagerService httpManagerService)
		{
			_serviceType = typeof(AuthenticationService);
			_xboxLiveDbContext = xboxLiveDbContext;
			_authenticationRepository = authenticationRepository;
			_httpManagerService = httpManagerService;
			_logger = x.CreateLogger<AuthenticationService>();
			_logger.LogInformation($"Service Registered");

			var config = ConfigurationLoader.Retrieve();
			_options = new XboxLiveAuthenticationOptions
			{
				MicrosoftAccount = config.Get("XboxLive:Authentication:MicrosoftAccount"),
				MicrosoftAccountPassword = config.Get("XboxLive:Authentication:MicrosoftAccountPassword"),
				ApiEndpoint = config.Get("XboxLive:Authentication:ApiEndpoint")
			};
		}

		private Type _serviceType { get; set; }

		private XboxLiveDbContext _xboxLiveDbContext { get; set; }

		private IAuthenticationRepository _authenticationRepository { get; set; }

		private HttpManagerService _httpManagerService { get; set; }

		private XboxLiveAuthenticationOptions _options { get; set; }

		private ILogger _logger { get; set; }

		public async Task<Authentication> GetAuthenticationAsync()
		{
			_logger.LogVerbose($"Entered GetToken");

			var authentication = (await _authenticationRepository.GetAllAsync()).FirstOrDefault();
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

			var xboxLiveAuthentication= await _httpManagerService.ExecuteRequestAsync<XboxLiveAuthenticateResponse>(HttpMethod.POST,
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
			authentication = await _authenticationRepository.UpdateAsync(authentication);

			return authentication;
		}

		public async Task<string> GetTokenAsync()
		{
			return (await GetAuthenticationAsync()).Token;
		}
	}
}
