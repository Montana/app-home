using Microsoft.AspNet.Mvc;

namespace Branch.Web.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View("~/Branch.Web/Views/Home/Index");
		}
		
		public IActionResult Error()
		{
			return View("~/Branch.Web/Views/Shared/Error.cshtml");
		}
	}
}
