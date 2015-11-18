using System.Linq;
using System.Threading.Tasks;
using Branch.Web.Areas.Halo5.ViewModels;
using Microsoft.AspNet.Mvc;
using Branch.Helpers.Extentions;

namespace Branch.Web.Areas.Halo5.Controllers
{
	public class ServiceRecordController
		: ControllerBase
	{
		[HttpGet("service-record")]
		public async Task<IActionResult> Index(string gamertag)
		{
			gamertag = gamertag.FromSlug();

			var arenaServiceRecordTask = ServiceRecordService.GetArenaServiceRecord(gamertag);
			var warzoneServiceRecordTask = ServiceRecordService.GetWarzoneServiceRecord(gamertag);
			await Task.WhenAll(arenaServiceRecordTask, warzoneServiceRecordTask);

			return View(
				new ServiceRecordViewModel(
					arenaServiceRecordTask.Result.Results.First().Result,
					warzoneServiceRecordTask.Result.Results.First().Result));
		}
	}
}
