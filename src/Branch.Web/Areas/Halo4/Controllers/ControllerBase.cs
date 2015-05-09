using Branch.Game.Halo4.Services;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Areas.Halo4.Controllers
{
	[Area("Halo4")]
	public class ControllerBase : Controller
	{
		[FromServices]
		public ServiceRecordService ServiceRecordService { get; set; }
	}
}
