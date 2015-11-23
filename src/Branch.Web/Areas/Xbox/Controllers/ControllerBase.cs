using Branch.Service.XboxLive.Services;
using Branch.Web.Attributes;
using Branch.Web.Filters;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Areas.XboxLive.Controllers
{
	[ActionTimer]
	[Area("Xbox")]
	[Route("xbox/{gamertag}/")]
	[ServiceRequired(ServiceRequired.Service.XboxLive)]
	public class ControllerBase : Controller
	{
		[FromServices]
		public UserService UserService { get; set; }
	}
}
