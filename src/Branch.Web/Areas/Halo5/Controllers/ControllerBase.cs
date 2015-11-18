using Branch.Service.Halo5.Services;
using Branch.Web.Attributes;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Areas.Halo5.Controllers
{
	[Area("Halo5")]
	[Route("xbox/{gamertag}/halo-5/")]
	[ServiceRequired(ServiceRequired.Service.Halo5)]
	public class ControllerBase : Controller
	{
		[FromServices]
		public ServiceRecordService ServiceRecordService { get; set; }

		[FromServices]
		public ProfileService ProfileService { get; set; }

		[FromServices]
		public MatchHistoryService MatchHistoryService { get; set; }
	}
}
