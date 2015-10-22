using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public class ServiceRecordViewModel
		: ViewModelBase
	{
		public ServiceRecordViewModel(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory)
			: base(serviceRecord, gameHistory)
		{ }
	}
}
