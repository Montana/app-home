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
using Branch.Service.Xuid.Exceptions;
using Branch.Service.Xuid.Services;

namespace Branch.Service.Halo4.Services
{
	public class MatchHistoryService
		: ServiceBase<MatchHistoryService>
	{
		public MatchHistoryService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, Halo4DbContext halo4DbContext, Halo4DdbRepository halo4DdbRepository, AuthenticationService authenticationService, IGameHistoryRepository gameHistoryRepository, IServiceRecordRepository serviceRecordRepository)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{
			_serviceRecordRepository = serviceRecordRepository;
			_gameHistoryRepository = gameHistoryRepository;
		}

		private IServiceRecordRepository _serviceRecordRepository;

		private IGameHistoryRepository _gameHistoryRepository;

		private const string GetMatchesUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/matches?count={1}&startat={2}";
		private const string GetGameModeMatchesUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/matches?count={1}&startat={2}&gamemodeid={3}";

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(0, 5, 0);

		public async Task<GameHistoryDetailsFull> GetGameHistory(Int64 xuid, int count = 5, int startAt = 0)
		{
			return await GetGameHistory(xuid, null, count, startAt);
		}

		public async Task<GameHistoryDetailsFull> GetGameHistory(Int64 xuid, GameMode gameMode, int count = 5, int startAt = 0)
		{
			return await GetGameHistory(xuid, gameMode, count, startAt, false);
		}

		public async Task<GameHistoryDetailsFull> GetGameHistory(Int64 xuid, Nullable<GameMode> gameMode, int count = 5, int startAt = 0, bool takeCached = false)
		{
			// retrieve gamertag (via xuid) from xuid lookup service
			var playerGamertag = await XuidLookupService.LookupGamertagAsync(xuid);

			var spartanToken = await AuthenticationService.GetSpartanTokenAsync();
			var validAuthentication = spartanToken != null;
			var gameHistoryUri = new Uri(gameMode != null
				? string.Format(GetGameModeMatchesUrl, playerGamertag, count, startAt, (int)gameMode)
				: string.Format(GetMatchesUrl, playerGamertag, count, startAt));

			// Get Game History metadata from Database
			var gameHistoryMetadata = _gameHistoryRepository.Where(gh => gh.GameMode == gameMode && gh.Count == count && gh.StartAt == startAt).Where(gh => gh?.ServiceRecord?.Xuid == xuid).FirstOrDefault();
			GameHistoryDetailsFull cachedGameHistory = null;
			if (gameHistoryMetadata != null)
			{
				// Return data from DocumentDb if we're taking cached version, or the auhentication is broken
				if (!validAuthentication || takeCached)
				{
					// Get Game History from DocumentDb
					cachedGameHistory = Halo4DdbRepository.GetById<GameHistoryDetailsFull>(gameHistoryMetadata.DocumentId);

					// If the cached Game History exists, return it
					if (cachedGameHistory != null)
						return cachedGameHistory;
				}
			}

			// If auth is broken, throw exception
			if (!validAuthentication)
				throw new Halo4AuthenticationDownException();

			// Get Game History from 343's Halo Service
			var gameHistoryResponse = await HttpManagerService.ExecuteRequestAsync<GameHistoryDetailsFull>(HttpMethod.GET, gameHistoryUri, headers:
				new Dictionary<string, string>
				{
					{ "X-343-Authorization-Spartan", spartanToken }
				});

			// Check if something went wrong with the request or parsing
			if (gameHistoryResponse == null)
				return null; // TODO: find a way to acess this data and throw the relevant exception

			// Check response
			switch (gameHistoryResponse.StatusCode)
			{
				case StatusCode.NoData:
					throw new PlayerHasntPlayedHalo4Exception();

				case StatusCode.PlayerDoesntExist:
					throw new PlayerDoesntExistException();
			}

			// Update documentdb and return data if it exists in the DocumentDb
			if (gameHistoryMetadata != null)
				cachedGameHistory =
					await Halo4DdbRepository.UpdateAsync<GameHistoryDetailsFull>(gameHistoryMetadata.DocumentId, gameHistoryResponse);
			else
				cachedGameHistory = await Halo4DdbRepository.CreateAsync<GameHistoryDetailsFull>(gameHistoryResponse);

			// Query (or, on fallback, create) Service Record
			var serviceRecord = _serviceRecordRepository.Where(sr => sr.Xuid == xuid).FirstOrDefault();
			if (serviceRecord == null)
				_serviceRecordRepository.Add(new ServiceRecord
				{
					DocumentId = null,
					Xuid = xuid,
					ServiceTag = "YOLO"
				});

			// Query (or, on fallback, create) Game History
			var gameHistory = _gameHistoryRepository
				.Where(gh => gh.ServiceRecord.Xuid == xuid && gh.GameMode == gameMode && gh.Count == gh.Count && gh.StartAt == startAt)
				.FirstOrDefault();
			if (gameHistory == null)
				_gameHistoryRepository.Add(new GameHistory
				{
					DocumentId = cachedGameHistory.Id,
					Count = count,
					GameMode = gameMode,
					ServiceRecordId = serviceRecord.Id
				});
			else
			{
				gameHistory.DocumentId = cachedGameHistory.Id;
				_gameHistoryRepository.Update(gameHistory);
			}

			// Return Game History to user
			return cachedGameHistory;
		}
	}
}
