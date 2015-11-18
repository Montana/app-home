using System.Threading.Tasks;
using Branch.Helpers.Extentions;
using Branch.Web.Areas.Halo4.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Web.Areas.Halo4.Controllers
{
	public class SpecializationsController
		: ControllerBase
	{
		[HttpGet("specializations")]
		public async Task<IActionResult> Index(string gamertag)
		{
			gamertag = gamertag.FromSlug();

			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);
			var gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: 20);
			
			return View(new SpecializationsViewModel(serviceRecord, gameHistory));
		}
	}
}
