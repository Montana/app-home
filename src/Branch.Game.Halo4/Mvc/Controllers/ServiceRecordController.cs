using System.Threading.Tasks;
using Branch.Game.Halo4.Mvc.ViewModels;
using Branch.Game.Halo4.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Game.Halo4.Mvc.Controllers
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
			var serviceRecordTask = await ServiceRecordService.GetServiceRecord(gamertag);
			var gameHistoryTask = await MatchHistoryService.GetGameHistory(gamertag, GameMode.WarGames);
			//await Task.WhenAll(serviceRecordTask, gameHistoryTask);
			
			return View("~/Branch.Game.Halo4/Mvc/Views/ServiceRecord/Index", new ServiceRecordViewModel(serviceRecordTask, gameHistoryTask));
		}
	}
}
