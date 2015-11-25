using System.Threading.Tasks;
using Branch.Helpers.Services;
using Microsoft.Extensions.Logging;
using Branch.Service.Halo5.Database;
using Branch.Service.Halo5.DocumentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Branch.Service.Halo5.Database.Enums;
using Branch.Service.Halo5.Database.Models;
using Branch.Service.Halo5.Database.Repositories.Interfaces;
using Branch.Service.Xuid.Exceptions;
using Branch.Service.Xuid.Services;
using Branch.Service.Halo5.Models.Api.Enums;
using Branch.Service.Halo5.Models.Api;
using Branch.Helpers.Extentions;

namespace Branch.Service.Halo5.Services
{
	public class MatchHistoryService
		: ServiceBase<MatchHistoryService>
	{
		public MatchHistoryService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService,
			XuidLookupService xuidLookupService, Halo5DbContext halo5DbContext, Halo5DdbRepository halo5DdbRepository,
			AuthenticationService authenticationService, IMatchHistoryRepository matchHistoryRepository)
			: base(
				loggerFactory, httpManagerService, xuidLookupService, halo5DbContext, halo5DdbRepository, authenticationService)
		{
			_matchHistoryRepository = matchHistoryRepository;
		}

		private readonly IMatchHistoryRepository _matchHistoryRepository;

		private const string GetMatchesUrl = "https://www.haloapi.com/stats/h5/players/{0}/matches?modes={1}&start={2}&count={3}";

		private readonly TimeSpan _cacheRefreshTime = new TimeSpan(0, 1, 0);

		public async Task<Response<Models.Api.MatchHistory>> GetMatchesAsync(string gamertag)
		{
			return await GetMatchesAsync(gamertag, false, GameMode.All, 0, 25);
		}

		public async Task<Response<Models.Api.MatchHistory>> GetMatchesAsync(string gamertag, bool takeCached, GameMode mode, int start = 0, int count = 25)
		{
			// Get Player Gamertag
			var playerXuid = await XuidLookupService.LookupXuidAsync(gamertag);

			// Get Match History metadata from repository
			var matchHistoryMetadata = _matchHistoryRepository
				.Where(sr =>
					sr.Xuid == playerXuid &&
					sr.Mode == mode &&
					sr.Start == start &&
					sr.Count == count).FirstOrDefault();

			Response<Models.Api.MatchHistory> cachedMatchHistory;
			if (matchHistoryMetadata != null)
			{
				// Return data from DocumentDb if we're taking cached version, or it's expired
				if (takeCached || matchHistoryMetadata.UpdatedAt + _cacheRefreshTime > DateTime.UtcNow)
				{
					// Get Service Record from DocumentDb
					cachedMatchHistory = Halo5DdbRepository.GetById<Response<Models.Api.MatchHistory>>(matchHistoryMetadata.DocumentId);

					// If the cached Service Record exist, return it
					if (cachedMatchHistory != null)
						return cachedMatchHistory;
				}
			}

			var modes = string.Empty;
			if (mode == GameMode.All)
				modes = "arena,campaign,custom,warzone";
			else
				modes = mode.ToString().ToSlug();

			// Populate template match history url
			var getMatchHistoryUri = new Uri(string.Format(GetMatchesUrl, gamertag, modes, start, count));

			// Get Match History from 343's Halo Service
			var matchHistoryResponse = await HttpManagerService.ExecuteRequestAsync<Response<Models.Api.MatchHistory>>(HttpMethod.GET, getMatchHistoryUri,
				headers: new Dictionary<string, string>
				{
					{ "Ocp-Apim-Subscription-Key", AuthenticationService.GetAuthentication() }
				});

			// Update documentdb and return data if it exists in the DocumentDb
			if (matchHistoryMetadata != null)
				cachedMatchHistory = await Halo5DdbRepository.UpdateAsync(matchHistoryMetadata.DocumentId, matchHistoryResponse);
			else
				cachedMatchHistory = await Halo5DdbRepository.CreateAsync(matchHistoryResponse);

			var matchHistory = _matchHistoryRepository
				.Where(sr =>
					sr.Xuid == playerXuid &&
					sr.Mode == mode &&
					sr.Start == start &&
					sr.Count == count).FirstOrDefault();

			if (matchHistory == null)
				_matchHistoryRepository.Add(new Database.Models.MatchHistory
				{
					Xuid = playerXuid,
					Mode = mode,
					Count = count,
					Start = 0,
					DocumentId = cachedMatchHistory.Id
				});
			else
			{
				matchHistory.DocumentId = cachedMatchHistory.Id;
				_matchHistoryRepository.Update(matchHistory);
			}

			return cachedMatchHistory;
		}
	}
}
