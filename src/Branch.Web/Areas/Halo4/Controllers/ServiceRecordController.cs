using System.Threading.Tasks;
using Branch.Web.Areas.Halo4.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;
using Branch.Helpers.Extentions;

namespace Branch.Web.Areas.Halo4.Controllers
{
	public class ServiceRecordController
		: ControllerBase
	{
		[HttpGet("service-record")]
		public async Task<IActionResult> Index(string gamertag)
		{
			gamertag = gamertag.FromSlug();

			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);
			var gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: 20);
			
			return View(new ServiceRecordViewModel(serviceRecord, gameHistory));
		}
	}
}
