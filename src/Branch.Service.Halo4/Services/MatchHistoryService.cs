using System.Threading.Tasks;
using Branch.Helpers.Services;
using Branch.Service.Halo4.Database.Models;
using Microsoft.Framework.Logging;
using Branch.Service.Halo4.Database;
using Branch.Service.Halo4.DocumentDb;
using System;
using Microsoft.Halo.Core.DataContracts;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Enums;
using Branch.Service.Halo4.Database.Repositories.Interfaces;
using Branch.Service.Halo4.Exceptions;
using Branch.Helpers.Exceptions;

namespace Branch.Service.Halo4.Services
{
	public class MatchHistoryService
		: ServiceBase<MatchHistoryService>
	{
		public MatchHistoryService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, Halo4DbContext halo4DbContext, Halo4DdbRepository halo4DdbRepository, AuthenticationService authenticationService, IGameHistoryRepository gameHistoryRepository, IServiceRecordRepository serviceRecordRepository)
			: base(loggerFactory, httpManagerService, halo4DbContext, halo4DdbRepository, authenticationService)
		{
			_serviceRecordRepository = serviceRecordRepository;
			_gameHistoryRepository = gameHistoryRepository;
		}

		private IServiceRecordRepository _serviceRecordRepository;

		private IGameHistoryRepository _gameHistoryRepository;

		private const string GetMatchesUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/matches?count={1}&startat={2}";
		private const string GetGameModeMatchesUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/matches?count={1}&startat={2}&gamemodeid={3}";

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(0, 5, 0);

		public async Task<GameHistoryDetailsFull> GetGameHistory(string gamertag, int count = 5, int startAt = 0)
		{
			return await GetGameHistory(gamertag, null, count, startAt);
		}

		public async Task<GameHistoryDetailsFull> GetGameHistory(string gamertag, GameMode gameMode, int count = 5, int startAt = 0)
		{
			return await GetGameHistory(gamertag, gameMode, count, startAt, false);
		}

		public async Task<GameHistoryDetailsFull> GetGameHistory(string gamertag, Nullable<GameMode> gameMode, int count = 5, int startAt = 0, bool takeCached = false)
		{
			var spartanToken = await AuthenticationService.GetSpartanTokenAsync();
			var validAuthentication = spartanToken != null;
			var gameHistoryUri = new Uri(gameMode != null
				? string.Format(GetGameModeMatchesUrl, gamertag, count, startAt, (int) gameMode)
				: string.Format(GetMatchesUrl, gamertag, count, startAt));

			// Get Game History metadata from Database
			var gameHistoryMetadata = _gameHistoryRepository.Where(gh => /*gh.ServiceRecord.Gamertag == gamertag &&*/ gh.GameMode == gameMode && gh.Count == count && gh.StartAt == startAt).Where(gh => gh.ServiceRecord.Gamertag == gamertag).FirstOrDefault();
			GameHistoryDetailsFull cachedGameHistory = null;
			if (gameHistoryMetadata != null)
			{
				// Return data from DocumentDb if we're taking cached version, it's expired, or the auhentication is broken
				if (!validAuthentication || takeCached || gameHistoryMetadata.UpdatedAt + CacheRefreshTime > DateTime.UtcNow)
				{
					// Get Game History from DocumentDb
					cachedGameHistory = Halo4DdbRepository.GetById<GameHistoryDetailsFull>(gameHistoryMetadata.DocumentId);

					// If the cached Game History exist, return it
					if (cachedGameHistory != null)
						return cachedGameHistory;
				}
			}

			// If auth is broken, throw exception
			if (!validAuthentication)
				throw new Halo4AuthenticationDownException();

			// Get Service Record from 343's Halo Service
			var gameHistory = await HttpManagerService.ExecuteRequestAsync<GameHistoryDetailsFull>(HttpMethod.GET, gameHistoryUri, headers:
				new Dictionary<string, string>
				{
					{ "X-343-Authorization-Spartan", spartanToken }
				});

			// Check if something went wrong with the request or parsing
			if (gameHistory == null)
				return null; // TODO: find a way to acess this data and throw the relevant exception

			// Check response
			switch (gameHistory.StatusCode)
			{
				case StatusCode.NoData:
					throw new PlayerHasntPlayedHalo4Exception();
					
				case StatusCode.PlayerDoesntExist:
					throw new PlayerDoesntExistException();
			}

			// Update documentdb and return data if it exists in the DocumentDb
			if (gameHistoryMetadata != null)
				return await Halo4DdbRepository.UpdateAsync<GameHistoryDetailsFull>(gameHistoryMetadata.DocumentId, gameHistory);

			// Create DocumentDb and Database entry
			cachedGameHistory = await Halo4DdbRepository.CreateAsync<GameHistoryDetailsFull>(gameHistory);
			var serviceRecord = _serviceRecordRepository.Where(sr => sr.Gamertag == gamertag).FirstOrDefault() ?? await _serviceRecordRepository.AddAsync(new ServiceRecord
				{
					DocumentId = null,
					Gamertag = gamertag,
					ServiceTag = "SWAG"
				});
			await _gameHistoryRepository.AddAsync(new GameHistory
			{
				DocumentId = cachedGameHistory.Id,
				Count = count,
				GameMode = gameMode,
				ServiceRecordId = serviceRecord.Id
			});

			// Return Game History to user
			return gameHistory;
		}
	}
}
