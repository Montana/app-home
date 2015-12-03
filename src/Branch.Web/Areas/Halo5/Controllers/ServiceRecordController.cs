using System.Linq;
using System.Threading.Tasks;
using Branch.Web.Areas.Halo5.ViewModels;
using Microsoft.AspNet.Mvc;
using Branch.Helpers.Extentions;
using Branch.Service.Halo5.Models.Api.Enums;

namespace Branch.Web.Areas.Halo5.Controllers
{
	public class ServiceRecordController
		: ControllerBase
	{
		[HttpGet("service-record")]
		public async Task<IActionResult> Index(string gamertag)
		{
			// Get Xbox Live Profile
			var xboxLiveProfile = await XuidLookupService.GenerateXboxLiveProfileAsync(gamertag.FromSlug());

			// Check Gamertag has played Halo 5
			await ProfileService.GetProfileEmblemAsync(xboxLiveProfile, size: 95);

			// Get Halo 5 Stats
			var arenaServiceRecordTask = ServiceRecordService.GetArenaServiceRecord(xboxLiveProfile);
			var warzoneServiceRecordTask = ServiceRecordService.GetWarzoneServiceRecord(xboxLiveProfile);
			var customsServiceRecordTask = ServiceRecordService.GetCustomsServiceRecord(xboxLiveProfile);
			var campaignServiceRecordTask = ServiceRecordService.GetCampaignServiceRecord(xboxLiveProfile);
			var matchHistoryTask = MatchHistoryService.GetMatchesAsync(xboxLiveProfile, false, GameMode.All, count: 24);
			var profileEmblem = ProfileService.GetProfileEmblemAsync(xboxLiveProfile);
			var profileSpartanModel = ProfileService.GetProfileSpartanModelAsync(xboxLiveProfile);
			await Task.WhenAll(arenaServiceRecordTask, warzoneServiceRecordTask, 
				customsServiceRecordTask, campaignServiceRecordTask,
				matchHistoryTask, profileEmblem, profileSpartanModel);

			arenaServiceRecordTask.Result.Results.First().Result.PlayerId.Emblem = profileEmblem.Result;
			arenaServiceRecordTask.Result.Results.First().Result.PlayerId.SpartanModel = profileSpartanModel.Result;
			
			return View(
				new ServiceRecordViewModel(
					arenaServiceRecordTask.Result.Results.First().Result,
					warzoneServiceRecordTask.Result.Results.First().Result,
					customsServiceRecordTask.Result.Results.First().Result,
					campaignServiceRecordTask.Result.Results.First().Result,
					matchHistoryTask.Result));
		}
	}
}
