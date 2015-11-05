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
		private const int _count = 20;

		[HttpGet("match-history/{modeSlug}")]
		public async Task<IActionResult> Index(string gamertag, string modeSlug)
		{
			return await IndexPage(gamertag, modeSlug, 0);
		}
		
		[HttpGet("match-history/{modeSlug}/page/{matchPage}")]
		public async Task<IActionResult> IndexPage(string gamertag, string modeSlug, int matchPage = 0)
		{
			// Check Page is valid
			if (matchPage < 0)
				return RedirectToAction("Index", new { gamertag, modeSlug, page = 0 });

			// Check Mode is valid
			GameMode matchHistoryGameMode;
			if (!modeSlug.TryParseToEnum(true, out matchHistoryGameMode)) return RedirectToAction("Index", new { gamertag, matchSlug = GameMode.WarGames.ToString().ToSlug() });
			GameHistoryDetailsFull gameHistory;
			GameHistoryDetailsFull gameHistoryView;

			// Get Service Record
			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);
			
			// Get Matches
			gameHistoryView = gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, matchHistoryGameMode, count: _count, startAt: (matchPage * _count));
			if (matchHistoryGameMode != GameMode.WarGames)
				gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: _count);
			
			return View("Index", new MatchHistoryViewModel(serviceRecord, gameHistory, (uint) matchPage, _count, matchHistoryGameMode, gameHistoryView));
		}
	}
}
