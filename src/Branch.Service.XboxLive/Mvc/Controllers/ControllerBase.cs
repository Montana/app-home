using Branch.Service.XboxLive.Services;
using Microsoft.AspNet.Mvc;

namespace Branch.Service.XboxLive.Mvc.Controllers
{
	[Route("Xbox/{gamertag}/")]
	public class ControllerBase : Controller
	{
		[FromServices]
		public UserService UserService { get; set; }
	}
}
