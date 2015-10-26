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
		[FromServices]
		public MatchHistoryService MatchHistoryService { get; set; }

		[HttpGet]
		[HttpGet("ServiceRecord")]
		public async Task<IActionResult> Index(string gamertag)
		{
			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);
			var gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: 20);
			
			return View("/Areas/Halo4/Views/ServiceRecord/Index", new ServiceRecordViewModel(serviceRecord, gameHistory));
		}
	}
}
