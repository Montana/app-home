using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Areas.Halo5.Controllers
{
	public class ServiceRecordController
		: ControllerBase
	{
		[HttpGet("service-record")]
		public async Task<IActionResult> Index(string gamertag)
		{
			var arenaServiceRecord = await ServiceRecordService.GetArenaServiceRecord(gamertag);

			return Json(arenaServiceRecord);
		}
	}
}
