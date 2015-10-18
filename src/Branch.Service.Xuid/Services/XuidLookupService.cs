using System;
using Branch.Helpers.Services;
using Branch.Service.Xuid.Database;
using Microsoft.Framework.Logging;
using System.Threading.Tasks;
using Branch.Service.Xuid.Exceptions;
using System.Collections.Generic;
using Microsoft.Xbox.Core.DataContracts;
using Microsoft.Xbox.Core.DataContracts.Enum;
using System.Linq;

namespace Branch.Service.Xuid.Services
{
	public class XuidLookupService
		: ServiceBase<XuidLookupService>
	{
		public XuidLookupService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidDbContext xuidDbContext, AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, xuidDbContext, authenticationService)
		{ }

		private const string GetGamertagProfileUrl = "https://profile.xboxlive.com/users/gt({0})/profile/settings";

		public async Task<long> LookupAsync(string gamertag)
		{
			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var validAuthentication = authentication != null && authentication.Token != null;
			var durangoTitleHistoryUri = new Uri(string.Format(GetGamertagProfileUrl, gamertag));

			if (!validAuthentication)
				throw new XboxLiveAuthenticationDownException();

			var profileDetails = await HttpManagerService.ExecuteRequestAsync<ProfileUsers>(HttpMethod.GET, durangoTitleHistoryUri, headers:
				new Dictionary<string, string>
				{
					{ "x-xbl-contract-version", "2" },
					{ "Authorization", string.Format("XBL3.0 x={0};{1}", authentication.UserHash, authentication.Token) }
				});

			switch (profileDetails.StatusCode)
			{
				case StatusCode.UserDoesntExist:
					throw new PlayerDoesntExistException();
			}

			return profileDetails.Users.First().Xuid;
		}
	}
}
