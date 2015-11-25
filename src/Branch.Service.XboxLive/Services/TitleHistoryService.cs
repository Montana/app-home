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
	public class TitleHistoryService
		: ServiceBase<TitleHistoryService>
	{
		public TitleHistoryService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, XboxLiveDbContext halo4DbContext, XboxLiveDdbRepository halo4DdbRepository, AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{ }

		public const string GetDurangoTitleHistoryUrl = "https://achievements.xboxlive.com/users/{0}({1})/history/titles?skipItems={2}&maxItems={3}&orderBy={4}";

		public const string GetLegacyTitleHistoryUrl = "https://achievements.xboxlive.com/users/{0}({1})/history/titles?platforms=1,2,15,16,17&types=1,3&skipItems={2}&maxItems={3}&orderBy={4}";

		public async Task<UserTitleHistory<DurangoUserTitle>> GetDurangoTitleHistory(Int64 xuid, int start, int count)
		{
			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var validAuthentication = authentication != null && authentication.Token != null;
			var durangoTitleHistoryUri = new Uri(string.Format(GetDurangoTitleHistoryUrl, "xuid", xuid, start, count, "unlockTime"));

			if (!validAuthentication)
				throw new XboxLiveAuthenticationDownException();

			var profileDetails = await HttpManagerService.ExecuteRequestAsync<UserTitleHistory<DurangoUserTitle>>(HttpMethod.GET, durangoTitleHistoryUri, headers:
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
