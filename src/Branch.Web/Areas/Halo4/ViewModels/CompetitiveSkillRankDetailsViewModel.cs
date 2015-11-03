using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public class CompetitiveSkillRankDetailsViewModel
		: ViewModelBase
	{
		public CompetitiveSkillRankDetailsViewModel(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory,
			PlaylistDetailsFull playlist)
			: base(serviceRecord, gameHistory)
		{
			Playlist = playlist;
		}

		public PlaylistDetailsFull Playlist { get; set; }
	}
}
