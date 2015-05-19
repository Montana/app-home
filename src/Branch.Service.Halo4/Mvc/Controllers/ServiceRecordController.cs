using System.Threading.Tasks;
using Branch.Service.Halo4.Mvc.ViewModels;
using Branch.Service.Halo4.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Service.Halo4.Mvc.Controllers
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
			var gameHistory = await MatchHistoryService.GetGameHistory(gamertag, GameMode.WarGames);
			
			return View("~/Branch.Service.Halo4/Mvc/Views/ServiceRecord/Index", new ServiceRecordViewModel(serviceRecord, gameHistory));
		}
	}
}
