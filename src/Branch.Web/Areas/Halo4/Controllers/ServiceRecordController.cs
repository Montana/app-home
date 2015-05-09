using System.Threading.Tasks;
using Branch.Web.Areas.Halo4.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.Controllers
{
	public class ServiceRecordController
		: ControllerBase
	{
		public async Task<IActionResult> Index(string gamertag)
		{
			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);
			return View("Index", new ServiceRecordViewModel(serviceRecord));
		}
	}
}
