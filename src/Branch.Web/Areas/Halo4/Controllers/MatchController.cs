using System.Threading.Tasks;
using Branch.Service.Halo4.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;
using Branch.Helpers.Extentions;
using Branch.Web.Areas.Halo4.ViewModels;
using Microsoft.Halo.Core.DataContracts;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using System;
using System.Linq;

namespace Branch.Web.Areas.Halo4.Controllers
{
	public class MatchController
		: ControllerBase
	{
		[FromServices]
		public MatchService MatchService { get; set; }

		[HttpGet("match/{matchModeSlug}/{matchId}")]
		public async Task<IActionResult> Index(string gamertag, string matchModeSlug, string matchId)
		{
			// Check Mode is valid
			GameMode matchGameMode;
			if (!matchModeSlug.TryParseToEnum(true, out matchGameMode))
				return RedirectToAction("Index", "ServiceRecord", new { gamertag });
			
			// Get Service Record
			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);

			// Get Match and Match History
			var matchHistoryTask = MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: 20);
			var matchTask = MatchService.GetMatch(serviceRecord.Xuid, matchId);
			await Task.WhenAll(matchHistoryTask, matchTask);
			
			// Check Mode Slug is the same as the game
			if (matchGameMode != matchTask.Result.Game.Mode)
				return RedirectToAction("Index", new { gamertag, matchId, matchModeSlug = matchTask.Result.Game.Mode.GetDescription().ToString() });
			
			switch(matchGameMode)
			{
				case GameMode.WarGames:
				case GameMode.CustomGames:
					return View("WarGameDetails", new MatchViewModel<WarGameDetails>(serviceRecord, matchHistoryTask.Result, matchTask.Result.Game, matchGameMode));

				case GameMode.Campaign:
					throw new NotImplementedException();

				case GameMode.SpartanOps:
					throw new NotImplementedException();

				default:
					throw new InvalidOperationException();
			}
		}
	}
}
