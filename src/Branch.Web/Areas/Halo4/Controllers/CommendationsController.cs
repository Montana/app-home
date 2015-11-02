using System.Threading.Tasks;
using Branch.Service.Halo4.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;
using Branch.Web.Areas.Halo4.ViewModels;
using Branch.Helpers.Extentions;

namespace Branch.Web.Areas.Halo4.Controllers
{
	public class CommendationsController
		: ControllerBase
	{
		[FromServices]
		public MatchHistoryService MatchHistoryService { get; set; }

		[FromServices]
		public CommendationsService CommendationsService { get; set; }
		
		[HttpGet("commendations/{slug?}")]
		public async Task<IActionResult> Index(string gamertag, string slug = "weapons")
		{
			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);

			var gameHistoryTask = MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: 20);
			var commendationsTask = CommendationsService.GetCommendations(serviceRecord.Xuid);
			await Task.WhenAll(gameHistoryTask, commendationsTask);

			// Parse Slug to CommendationCategory
			CommendationCategory commendationCategory = CommendationCategory.Weapons;
			if (!slug.TryParseToEnum(true, out commendationCategory))
			{
				// TODO: create flash message system
				return RedirectToAction("Index", "Commendations", new[] { gamertag, slug = CommendationCategory.Weapons.ToString() });
			}
			
			return View(new CommendationsViewModel(serviceRecord, gameHistoryTask.Result, commendationsTask.Result, commendationCategory));
		}
	}
}
