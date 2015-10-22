using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public abstract class ViewModelBase
	{
		public ViewModelBase(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory)
		{
			ServiceRecord = serviceRecord;
			GameHistory = gameHistory;
		}

		public ServiceRecordDetailsFull ServiceRecord { get; set; }

		public GameHistoryDetailsFull GameHistory { get; set; }
	}
}
