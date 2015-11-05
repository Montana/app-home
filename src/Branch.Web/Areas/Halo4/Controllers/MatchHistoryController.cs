using System.Threading.Tasks;
using Branch.Web.Areas.Halo4.ViewModels;
using Branch.Service.Halo4.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;
using Branch.Helpers.Extentions;
using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.Controllers
{
	public class MatchHistoryController
		: ControllerBase
	{
		[HttpGet("match-history/{modeSlug}")]
		public async Task<IActionResult> Index(string gamertag, string modeSlug)
		{
			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);

			GameMode matchHistoryGameMode;
			if (!modeSlug.TryParseToEnum(true, out matchHistoryGameMode)) return RedirectToAction("Index", new { gamertag, matchSlug = GameMode.WarGames.ToString().ToSlug() });
			GameHistoryDetailsFull gameHistory;
			GameHistoryDetailsFull gameHistoryView;

			gameHistoryView = gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, matchHistoryGameMode, count: 20);
			if (matchHistoryGameMode != GameMode.WarGames)
				gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: 20);
			
			return View(new MatchHistoryViewModel(serviceRecord, gameHistory, matchHistoryGameMode, gameHistoryView));
		}
	}
}
