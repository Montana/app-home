using Branch.Service.Halo4.Services;
using Branch.Web.Attributes;
using Branch.Web.Filters;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Areas.Halo4.Controllers
{
	[ActionTimer]
	[Area("Halo4")]
	[Route("xbox/{gamertag}/halo-4/")]
	[ServiceRequired(ServiceRequired.Service.Halo4)]
	public class ControllerBase : Controller
	{
		[FromServices]
		public MetadataService MetadataService { get; set; }

		[FromServices]
		public ServiceRecordService ServiceRecordService { get; set; }

		[FromServices]
		public MatchHistoryService MatchHistoryService { get; set; }
	}
}
