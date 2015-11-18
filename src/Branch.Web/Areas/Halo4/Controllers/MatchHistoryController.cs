using System.Threading.Tasks;
using Branch.Web.Areas.Halo4.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;
using Branch.Helpers.Extentions;

namespace Branch.Web.Areas.Halo4.Controllers
{
	public class MatchHistoryController
		: ControllerBase
	{
		private const int Count = 20;

		[HttpGet("match-history/{modeSlug}")]
		public async Task<IActionResult> Index(string gamertag, string modeSlug)
		{
			return await IndexPage(gamertag.FromSlug(), modeSlug);
		}
		
		[HttpGet("match-history/{modeSlug}/page/{matchPage}")]
		public async Task<IActionResult> IndexPage(string gamertag, string modeSlug, int matchPage = 0)
		{
			gamertag = gamertag.FromSlug();

			// Check Page is valid
			if (matchPage < 0)
				return RedirectToAction("Index", new { gamertag, modeSlug, page = 0 });

			// Check Mode is valid
			GameMode matchHistoryGameMode;
			if (!modeSlug.TryParseToEnum(true, out matchHistoryGameMode)) return RedirectToAction("Index", new { gamertag, matchSlug = GameMode.WarGames.ToString().ToSlug() });

			// Get Service Record
			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);
			
			// Get Matches
			var gameHistoryViewTask = MatchHistoryService.GetGameHistory(serviceRecord.Xuid, matchHistoryGameMode, Count, (matchPage * Count));
			var gameHistoryTask = MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, Count);
			await Task.WhenAll(gameHistoryViewTask, gameHistoryTask);

			return View("Index", new MatchHistoryViewModel(serviceRecord, gameHistoryTask.Result, (uint) matchPage, Count, matchHistoryGameMode, gameHistoryViewTask.Result));
		}
	}
}
