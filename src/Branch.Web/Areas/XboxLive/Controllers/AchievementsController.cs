using Branch.Web.Areas.XboxLive.ViewModels;
using Branch.Service.XboxLive.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Xbox.Core.DataContracts;
using Microsoft.Xbox.Core.DataContracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Branch.Web.Areas.XboxLive.Controllers
{
	public class AchievementsController
		: ControllerBase
	{
		[FromServices]
		public TitleHistoryService TitleHistoryService { get; set; }

		[FromServices]
		public EntertainmentDiscoveryService EntertainmentDiscoveryService { get; set; }

		public const int AchievementsPerPage = 10;

		[HttpGet("Achievements/{page?}")]
		public async Task<IActionResult> Get(string gamertag, uint page = 0)
		{
			var profileSettings = await UserService.GetProfileDetails(gamertag);
			
			var durangoTitleHistoryTask = TitleHistoryService.GetDurangoTitleHistory(profileSettings.Users.First().Xuid, (AchievementsPerPage * (int)page), (AchievementsPerPage * (int)page) + AchievementsPerPage);
			var legacyTitleHistoryTask = TitleHistoryService.GetLegacyTitleHistory(profileSettings.Users.First().Xuid, (AchievementsPerPage * (int)page), (AchievementsPerPage * (int)page) + AchievementsPerPage);
			var profileSummaryTask = UserService.GetProfileSummary(profileSettings.Users.First().Xuid);
			var profilePreferredColorTask = UserService.GetProfileColour(profileSettings.Users.First().Settings.First(s => s.Id == "PreferredColor").Value);
			await Task.WhenAll(durangoTitleHistoryTask, legacyTitleHistoryTask, profileSummaryTask, profilePreferredColorTask);

			var userTitles = new List<UserTitle>();
			userTitles.AddRange(durangoTitleHistoryTask.Result.Titles);
			userTitles.AddRange(legacyTitleHistoryTask.Result.Titles);
			userTitles = userTitles.OrderByDescending(t => t is DurangoUserTitle ? (t as DurangoUserTitle).LastUnlock : (t as LegacyUserTitle).LastPlayed).ToList();
			var hasAnymoreTitles = durangoTitleHistoryTask.Result.PagingInfo.ContinuationToken != null && legacyTitleHistoryTask.Result.PagingInfo.ContinuationToken != null;

			var edsDurangoTitleInfo = await EntertainmentDiscoveryService.GetMediaDetailsBatch(durangoTitleHistoryTask.Result.Titles.Select(t => t.TitleId));

			return View("/Areas/XboxLive/Views/Achievements/Index", 
				new AchievementsViewModel(
					profileSettings.Users.First(), profileSummaryTask.Result, profilePreferredColorTask.Result, 
					page, userTitles, hasAnymoreTitles, edsDurangoTitleInfo));
		}

		[HttpGet("Achievements/{titleId}-{slug}")]
		public async Task<IActionResult> GetXboxOneAchievementDetails(string gamertag, string titleId, string slug)
		{
			var profileSettings = await UserService.GetProfileDetails(gamertag);

			// try parse game id
			UInt32 parsedTitleId = 0;
			if (UInt32.TryParse(titleId, out parsedTitleId))
				throw new ArgumentOutOfRangeException("titleId");

			var profileSummaryTask = UserService.GetProfileSummary(profileSettings.Users.First().Xuid);
			var profilePreferredColorTask = UserService.GetProfileColour(profileSettings.Users.First().Settings.First(s => s.Id == "PreferredColor").Value);
			var durangoTitleInfo = EntertainmentDiscoveryService.GetMediaDetails(parsedTitleId);
			await Task.WhenAll(durangoTitleInfo, profileSummaryTask, profilePreferredColorTask);
			
			//var edsDurangoTitleInfo = await EntertainmentDiscoveryService.GetMediaDetailsBatch(durangoTitleHistoryTask.Result.Titles.Select(t => t.TitleId));

			return View("/Areas/XboxLive/Views/Achievements/Index");
		}
	}
}
