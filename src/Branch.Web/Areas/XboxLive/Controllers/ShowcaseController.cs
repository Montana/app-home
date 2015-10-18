using System.Linq;
using System.Threading.Tasks;
using Branch.Web.Areas.XboxLive.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Branch.Web.Areas.XboxLive.Controllers
{
	public class ShowcaseController
		: ControllerBase
	{
		public async Task<IActionResult> Get(string gamertag)
		{
			var profileSettings = await UserService.GetProfileDetails(gamertag);

			var profileShowcaseTask = UserService.GetProfileShowcase(profileSettings.Users.First().Xuid);
			var profileSummaryTask = UserService.GetProfileSummary(profileSettings.Users.First().Xuid);
			var profilePreferredColorTask = UserService.GetProfileColour(profileSettings.Users.First().Settings.First(s => s.Id == "PreferredColor").Value);
			await Task.WhenAll(profileShowcaseTask, profileSummaryTask, profilePreferredColorTask);

			return View("/Areas/XboxLive/Views/Showcase/Index", new ShowcaseViewModel(profileSettings.Users.First(), profileSummaryTask.Result, profileShowcaseTask.Result, profilePreferredColorTask.Result));
		}
	}
}
