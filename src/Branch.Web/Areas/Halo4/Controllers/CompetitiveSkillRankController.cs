using System.Threading.Tasks;
using Branch.Service.Halo4.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Halo.Core.DataContracts.Enums;
using Branch.Web.Areas.Halo4.ViewModels;
using System.Linq;
using Branch.Helpers.Extentions;

namespace Branch.Web.Areas.Halo4.Controllers
{
	public class CompetitiveSkillRankController
		: ControllerBase
	{		
		[HttpGet("competitive-skill-rank")]
		public async Task<IActionResult> Index(string gamertag)
		{
			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);
			var gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: 20);

			return View(new CompetitiveSkillRankViewModel(serviceRecord, gameHistory));
		}

		[HttpGet("competitive-skill-rank/{playlistId}/{playlistSlug}")]
		public async Task<IActionResult> Details(string gamertag, string playlistSlug, int playlistId)
		{
			var playlist = (await MetadataService.GetMetadataAsync()).PlaylistsMetadata.Playlists.FirstOrDefault(p => p.Id == playlistId);
			if (playlist == null) return RedirectToAction("Index", new { gamertag });
			if (playlist.Name.ToSlug() != playlistSlug) return RedirectToAction("Details", new { gamertag, playlistId, slug = playlist.Name.ToSlug() });

			var serviceRecord = await ServiceRecordService.GetServiceRecord(gamertag);
			var gameHistory = await MatchHistoryService.GetGameHistory(serviceRecord.Xuid, GameMode.WarGames, count: 20);

			return View(new CompetitiveSkillRankDetailsViewModel(serviceRecord, gameHistory, playlist));
		}
	}
}
