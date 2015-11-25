using System;
using Branch.Helpers.Services;
using Branch.Service.Xuid.Database;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Branch.Service.Xuid.Exceptions;
using System.Collections.Generic;
using Microsoft.Xbox.Core.DataContracts;
using Microsoft.Xbox.Core.DataContracts.Enum;
using System.Linq;
using Branch.Service.Xuid.Database.Repositories.Interfaces;
using Branch.Service.Xuid.Database.Models;

namespace Branch.Service.Xuid.Services
{
	public class XuidLookupService
		: ServiceBase<XuidLookupService>
	{
		public XuidLookupService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidDbContext xuidDbContext, IXuidCacheRepository xuidCacheRepository, AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, xuidDbContext, xuidCacheRepository, authenticationService)
		{ }

		private const string GetGamertagProfileUrl = "https://profile.xboxlive.com/users/{0}({1})/profile/settings?settings=gamertag";

		public async Task<Int64> LookupXuidAsync(string gamertag)
		{
			// Check if we can retrieve the lookup from the local database
			var cachedLookup = XuidCacheRepository.GetByGamertag(gamertag);

			// Check if cached xuid exists, and is valid
			if (cachedLookup != null && cachedLookup.ExpiresAt > DateTime.UtcNow)
				return cachedLookup.Xuid;

			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var validAuthentication = authentication != null && authentication.Token != null;
			var xboxProfileSettingsUri = new Uri(string.Format(GetGamertagProfileUrl, "gamertag", gamertag));

			if (!validAuthentication)
				throw new XboxLiveAuthenticationDownException();

			var profileDetails = await HttpManagerService.ExecuteRequestAsync<ProfileUsers>(HttpMethod.GET, xboxProfileSettingsUri, headers:
				new Dictionary<string, string>
				{
					{ "x-xbl-contract-version", "2" },
					{ "Authorization", $"XBL3.0 x={authentication.UserHash};{authentication.Token}"}
				});

			switch (profileDetails.StatusCode)
			{
				case StatusCode.UserDoesntExist:
					throw new PlayerDoesntExistException();
			}

			// Retrieve profile details from container
			var userSettings = profileDetails.Users.First();

			// Save lookup to repository
			XuidCacheRepository.Add(new XuidCache
			{
				Gamertag = userSettings.Settings.First(s => s.Id == "Gamertag").Value,
				Xuid = userSettings.Xuid
			});

			// Return Xuid
			return userSettings.Xuid;
		}
		
		public async Task<string> LookupGamertagAsync(Int64 xuid)
		{
			// Check if we can retrieve the lookup from the local database
			var cachedLookup = XuidCacheRepository.GetByXuid(xuid);

			// Check if cached gamertag exists, and is valid
			if (cachedLookup != null && cachedLookup.ExpiresAt > DateTime.UtcNow)
				return cachedLookup.Gamertag;

			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var validAuthentication = authentication != null && authentication.Token != null;
			var xboxProfileSettingsUri = new Uri(string.Format(GetGamertagProfileUrl, "xuid", xuid));

			if (!validAuthentication)
				throw new XboxLiveAuthenticationDownException();

			var profileDetails = await HttpManagerService.ExecuteRequestAsync<ProfileUsers>(HttpMethod.GET, xboxProfileSettingsUri, headers:
				new Dictionary<string, string>
				{
					{ "x-xbl-contract-version", "2" },
					{ "Authorization", $"XBL3.0 x={authentication.UserHash};{authentication.Token}"}
				});

			switch (profileDetails.StatusCode)
			{
				case StatusCode.UserDoesntExist:
					throw new PlayerDoesntExistException();
			}

			// Retrieve profile details from container
			var userSettings = profileDetails.Users.First();

			// Save lookup to repository
			XuidCacheRepository.Add(new XuidCache
			{
				Gamertag = userSettings.Settings.First(s => s.Id == "Gamertag").Value,
				Xuid = userSettings.Xuid
			});

			// Return Gamertag
			return userSettings.Settings.First(s => s.Id == "Gamertag").Value;
		}
	}
}
