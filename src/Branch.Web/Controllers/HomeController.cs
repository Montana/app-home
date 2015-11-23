using Branch.Web.Filters;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Controllers
{
	[ActionTimer]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		
		public IActionResult Error()
		{
			return View();
		}
	}
}
