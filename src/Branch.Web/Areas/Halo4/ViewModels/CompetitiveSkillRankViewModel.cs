using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public class CompetitiveSkillRankViewModel
		: ViewModelBase
	{
		public CompetitiveSkillRankViewModel(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory)
			: base(serviceRecord, gameHistory)
		{ }
	}
}
