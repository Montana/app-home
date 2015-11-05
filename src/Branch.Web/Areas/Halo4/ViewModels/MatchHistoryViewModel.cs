using Microsoft.Halo.Core.DataContracts;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public class MatchHistoryViewModel
		: ViewModelBase
	{
		public MatchHistoryViewModel(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory, GameMode gameMode, GameHistoryDetailsFull gameHistoryView)
			: base(serviceRecord, gameHistory)
		{
			GameMode = gameMode;
			GameHistoryView = gameHistoryView;
		}

		public GameMode GameMode { get; set; }

		public GameHistoryDetailsFull GameHistoryView { get; set; }
	}
}
