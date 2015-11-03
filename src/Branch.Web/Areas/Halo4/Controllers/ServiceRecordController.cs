using System.Threading.Tasks;
using Branch.Web.Areas.Halo4.ViewModels;
using Branch.Service.Halo4.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Web.Areas.Halo4.Controllers
{
	public class ServiceRecordController
		: ControllerBase
	{
		[HttpGet]
		[HttpGet("service-record")]
		public async Task<IActionResult> Index(string gamertag)
		{
			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);
			var gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: 20);
			
			return View(new ServiceRecordViewModel(serviceRecord, gameHistory));
		}
	}
}
