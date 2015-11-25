using Branch.Helpers.Services;
using Branch.Service.XboxLive.Database;
using Branch.Service.XboxLive.DocumentDb;
using Branch.Service.Xuid.Exceptions;
using Branch.Service.Xuid.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Xbox.Core.DataContracts;
using Microsoft.Xbox.Core.DataContracts.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Branch.Service.XboxLive.Services
{
	public class AchievementService
		: ServiceBase<AchievementService>
	{
		public AchievementService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, XboxLiveDbContext halo4DbContext, XboxLiveDdbRepository halo4DdbRepository, AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{ }

		public const string GetTitleAchievementsUrl = "https://achievements.xboxlive.com/users/{0}({1})/achievements?titleId={2}&maxItems=2000&orderBy=EndingSoon";
		public const string GetLegacyTitleHistoryUrl = "{0}{1}{2}{3}{4}";
		
		public async Task<UserTitleHistory<DurangoUserTitle>> GetDurangoTitleHistory(Int64 xuid, UInt32 titleId)
		{
			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var validAuthentication = authentication != null && authentication.Token != null;
			var durangoTitleAchievementUri = new Uri(string.Format(GetTitleAchievementsUrl, "xuid", xuid, titleId));

			if (!validAuthentication)
				throw new XboxLiveAuthenticationDownException();

			var profileDetails = await HttpManagerService.ExecuteRequestAsync<UserTitleHistory<DurangoUserTitle>>(HttpMethod.GET, durangoTitleAchievementUri, headers:
				new Dictionary<string, string>
				{
					{ "x-xbl-contract-version", "1" },
					{ "Authorization", string.Format("XBL3.0 x={0};{1}", authentication.UserHash, authentication.Token) }
				});

			switch (profileDetails.StatusCode)
			{
				case StatusCode.UserDoesntExist:
					throw new PlayerDoesntExistException();
			}

			return profileDetails;
		}

		public async Task<UserTitleHistory<LegacyUserTitle>> GetLegacyTitleHistory(Int64 xuid, int start, int count)
		{
			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var validAuthentication = authentication != null && authentication.Token != null;
			var legacyTitleHistoryUri = new Uri(string.Format(GetLegacyTitleHistoryUrl, "xuid", xuid, start, count, "unlockTime"));

			if (!validAuthentication)
				throw new XboxLiveAuthenticationDownException();

			var profileDetails = await HttpManagerService.ExecuteRequestAsync<UserTitleHistory<LegacyUserTitle>>(HttpMethod.GET, legacyTitleHistoryUri, headers:
				new Dictionary<string, string>
				{
					{ "x-xbl-contract-version", "1" },
					{ "Authorization", string.Format("XBL3.0 x={0};{1}", authentication.UserHash, authentication.Token) }
				});

			switch (profileDetails.StatusCode)
			{
				case StatusCode.UserDoesntExist:
					throw new PlayerDoesntExistException();
			}

			return profileDetails;
		}
	}
}
