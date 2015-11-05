using Microsoft.Halo.Core.DataContracts;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public class MatchHistoryViewModel
		: ViewModelBase
	{
		public MatchHistoryViewModel(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory, uint page, uint count, GameMode gameMode, GameHistoryDetailsFull gameHistoryView)
			: base(serviceRecord, gameHistory)
		{
			Page = page;
			Count = count;
			GameMode = gameMode;
			GameHistoryView = gameHistoryView;
		}

		public uint Page { get; set; }

		public uint Count { get; set; }

		public GameMode GameMode { get; set; }

		public GameHistoryDetailsFull GameHistoryView { get; set; }
	}
}
