using System.Threading.Tasks;
using Branch.Helpers.Services;
using Branch.Game.Halo4.Database.Models;
using Microsoft.Framework.Logging;
using Branch.Game.Halo4.Database;
using Branch.Game.Halo4.DocumentDb;
using System;
using Microsoft.Azure.Documents;
using Microsoft.Halo.Core.DataContracts;
using System.Linq;
using System.Collections.Generic;

namespace Branch.Game.Halo4.Services
{
	public class MatchHistoryService
		: ServiceBase<MatchHistoryService>
	{
		public MatchHistoryService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, Halo4DbContext halo4DbContext, Halo4DdbRepository halo4DdbRepository, AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, halo4DbContext, halo4DdbRepository, authenticationService) { }

		private const string GetMatchesUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/matches?count={1}&startat={2}";
		private const string GetGameModeMatchesUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/matches?count={1}&startat={2}&gamemodeid={3}";

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(0, 5, 0);

		//public async Task<ServiceRecord> GetServiceRecord(string gamertag)
		//{
		//	return await GetServiceRecord(gamertag, false);
		//}

		//public async Task<ServiceRecord> GetServiceRecord(string gamertag, bool takeCached)
		//{
		//	var spartanToken = await AuthenticationService.GetSpartanTokenAsync();
		//	var validAuthentication = spartanToken != null;
		//	var getServiceRecordUri = new Uri(string.Format(GetServiceRecordUrl, gamertag));

		//	var cachedServiceRecord = Halo4DdbRepository.Find<ServiceRecord>(d => d.Gamertag == gamertag).FirstOrDefault();
		//	if (cachedServiceRecord != null)
		//	{
		//		if (takeCached || cachedServiceRecord.Timestamp + CacheRefreshTime > DateTime.UtcNow)
		//			return cachedServiceRecord;
		//	}

		//	var serviceRecord = await HttpManagerService.ExecuteRequestAsync<ServiceRecord>(HttpMethod.GET, new Uri(string.Format(GetServiceRecordUrl, gamertag)), headers: new Dictionary<string, string>()
		//	{
		//		{ "X-343-Authorization-Spartan", spartanToken }
		//	});

		//	if (serviceRecord == null)
		//		return null;

		//	return await Halo4DdbRepository.CreateAsync(serviceRecord);
		//}
	}
}
