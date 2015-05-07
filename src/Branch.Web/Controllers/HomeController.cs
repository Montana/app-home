using System.Threading.Tasks;
using Branch.Game.Halo4.Services;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Controllers
{
	public class HomeController : Controller
	{
		[FromServices]
		public ProfileService ProfileService { get; set; }

		public async Task<IActionResult> Index()
		{
			return View("Index", await ProfileService.GetTestAsync());
		}
		
		public IActionResult Error()
		{
			return View("~/Views/Shared/Error.cshtml");
		}
	}
}
