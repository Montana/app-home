using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public class SpecializationsViewModel
		: ViewModelBase
	{
		public SpecializationsViewModel(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory)
			: base(serviceRecord, gameHistory)
		{ }
	}
}
