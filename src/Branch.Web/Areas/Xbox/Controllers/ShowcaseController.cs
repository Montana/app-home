using System.Linq;
using System.Threading.Tasks;
using Branch.Web.Areas.XboxLive.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Areas.XboxLive.Controllers
{
	public class ShowcaseController
		: ControllerBase
	{
		[HttpGet("")]
		[HttpGet("showcase")]
		public async Task<IActionResult> Index(string gamertag)
		{
			var profileSettings = await UserService.GetProfileDetails(gamertag);

			var profileShowcaseTask = UserService.GetProfileShowcase(profileSettings.Users.First().Xuid);
			var profileSummaryTask = UserService.GetProfileSummary(profileSettings.Users.First().Xuid);
			var profilePreferredColorTask = UserService.GetProfileColour(profileSettings.Users.First().Settings.First(s => s.Id == "PreferredColor").Value);
			await Task.WhenAll(profileShowcaseTask, profileSummaryTask, profilePreferredColorTask);

			return View(new ShowcaseViewModel(profileSettings.Users.First(), profileSummaryTask.Result, profileShowcaseTask.Result, profilePreferredColorTask.Result));
		}
	}
}
