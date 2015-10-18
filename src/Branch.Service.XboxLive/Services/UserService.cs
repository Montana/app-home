using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Branch.Helpers.Services;
using Branch.Service.XboxLive.Database;
using Branch.Service.XboxLive.DocumentDb;
using Microsoft.Framework.Logging;
using Microsoft.Xbox.Core.DataContracts;
using Microsoft.Xbox.Core.DataContracts.Enum;
using Branch.Service.Xuid.Services;
using Branch.Service.Xuid.Exceptions;

namespace Branch.Service.XboxLive.Services
{
	public class UserService
		: ServiceBase<UserService>
	{
		public UserService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, XboxLiveDbContext halo4DbContext, XboxLiveDdbRepository halo4DdbRepository, AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{ }

		public const string GetProfileSettingsUrl = "https://profile.xboxlive.com/users/{0}({1})/profile/settings?settings=GameDisplayPicRaw,Gamerscore,Gamertag,AccountTier,XboxOneRep,PreferredColor,RealName,Bio,TenureLevel,Watermarks,Location,ShowUserAsAvatar";

		public const string GetProfileShowcaseUrl = "https://avty.xboxlive.com/users/{0}({1})/showcase";

		public const string GetProfileSummaryUrl = "https://social.xboxlive.com/users/{0}({1})/summary";

		public async Task<ProfileUsers> GetProfileDetails(string gamertag)
		{
			var playerXuid = await XuidLookupService.LookupAsync(gamertag);
			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var profileSettingsUri = new Uri(string.Format(GetProfileSettingsUrl, "gt", gamertag));

			var profileDetails = await HttpManagerService.ExecuteRequestAsync<ProfileUsers>(HttpMethod.GET, profileSettingsUri, headers:
				new Dictionary<string, string>
				{
					{ "x-xbl-contract-version", "3" },
					{ "Authorization", string.Format("XBL3.0 x={0};{1}", authentication.UserHash, authentication.Token) }
				});

			switch (profileDetails.StatusCode)
			{
				case StatusCode.UserDoesntExist:
					throw new PlayerDoesntExistException();
			}

			return profileDetails;
		}

		public async Task<ActivityItems> GetProfileShowcase(Int64 xuid)
		{
			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var validAuthentication = authentication != null && authentication.Token != null;
			var profileShowcaseUri = new Uri(string.Format(GetProfileShowcaseUrl, "xuid", xuid));

			if (!validAuthentication)
				throw new XboxLiveAuthenticationDownException();

			var profileShowcase = await HttpManagerService.ExecuteRequestAsync<ActivityItems>(HttpMethod.GET, profileShowcaseUri, headers:
				new Dictionary<string, string>
				{
					{ "x-xbl-contract-version", "5" },
					{ "Authorization", string.Format("XBL3.0 x={0};{1}", authentication.UserHash, authentication.Token) }
				});

			switch (profileShowcase.StatusCode)
			{
				case StatusCode.UserDoesntExist:
					throw new PlayerDoesntExistException();
			}

			return profileShowcase;
		}

		public async Task<ProfileSummary> GetProfileSummary(Int64 xuid)
		{
			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var validAuthentication = authentication != null && authentication.Token != null;
			var profileSummaryUri = new Uri(string.Format(GetProfileSummaryUrl, "xuid", xuid));

			if (!validAuthentication)
				throw new XboxLiveAuthenticationDownException();

			var profileSummary = await HttpManagerService.ExecuteRequestAsync<ProfileSummary>(HttpMethod.GET, profileSummaryUri, headers:
				new Dictionary<string, string>
				{
					{ "x-xbl-contract-version", "2" },
					{ "Authorization", string.Format("XBL3.0 x={0};{1}", authentication.UserHash, authentication.Token) }
				});

			switch (profileSummary.StatusCode)
			{
				case StatusCode.UserDoesntExist:
					throw new PlayerDoesntExistException();
			}

			return profileSummary;
		}

		public async Task<PreferredColor> GetProfileColour(string preferredColorUrl)
		{
			var profilePreferredColours = await HttpManagerService.ExecuteRequestAsync<PreferredColor>(HttpMethod.GET, new Uri(preferredColorUrl));
			return profilePreferredColours;
		}
	}
}
