﻿using System.Linq;
using System.Threading.Tasks;
using Branch.Web.Areas.Halo5.ViewModels;
using Microsoft.AspNet.Mvc;
using Branch.Helpers.Extentions;
using Branch.Service.Halo5.Models.Api.Enums;

namespace Branch.Web.Areas.Halo5.Controllers
{
	public class ServiceRecordController
		: ControllerBase
	{
		[HttpGet("service-record")]
		public async Task<IActionResult> Index(string gamertag)
		{
			gamertag = gamertag.FromSlug();
			
			var arenaServiceRecordTask = ServiceRecordService.GetArenaServiceRecord(gamertag);
			var warzoneServiceRecordTask = ServiceRecordService.GetWarzoneServiceRecord(gamertag);
			var matchHistoryTask = MatchHistoryService.GetMatchesAsync(gamertag, false, GameMode.All, count: 24);
			var profileEmblem = ProfileService.GetProfileEmblemAsync(gamertag);
			var profileSpartanModel = ProfileService.GetProfileSpartanModelAsync(gamertag);
			await Task.WhenAll(arenaServiceRecordTask, warzoneServiceRecordTask, matchHistoryTask, profileEmblem, profileSpartanModel);

			arenaServiceRecordTask.Result.Results.First().Result.PlayerId.Emblem = profileEmblem.Result;
			arenaServiceRecordTask.Result.Results.First().Result.PlayerId.SpartanModel = profileSpartanModel.Result;
			
			return View(
				new ServiceRecordViewModel(
					arenaServiceRecordTask.Result.Results.First().Result,
					warzoneServiceRecordTask.Result.Results.First().Result,
					matchHistoryTask.Result));
		}
	}
}
