using System.Linq;
using System.Threading.Tasks;
using Branch.Service.XboxLive.Mvc.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Branch.Service.XboxLive.Mvc.Controllers
{
	public class ProfileController
		: ControllerBase
	{
		public async Task<IActionResult> Get(string gamertag)
		{
			var profileSettings = await UserService.GetProfileDetails(gamertag);

			var profileShowcaseTask = UserService.GetProfileShowcase(profileSettings.Users.First().Xuid);
			var profileSummaryTask = UserService.GetProfileSummary(profileSettings.Users.First().Xuid);
			var profilePreferredColorTask = UserService.GetProfileColour(profileSettings.Users.First().Settings.First(s => s.Id == "PreferredColor").Value);
			await Task.WhenAll(profileShowcaseTask, profileSummaryTask, profilePreferredColorTask);

			return View("~/Branch.Service.XboxLive/Mvc/Views/Profile/Index", new ProfileViewModel(profileSettings.Users.First(), profileSummaryTask.Result, profileShowcaseTask.Result, profilePreferredColorTask.Result));
		}
	}
}
