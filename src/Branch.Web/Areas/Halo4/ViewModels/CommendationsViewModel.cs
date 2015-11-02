using Microsoft.Halo.Core.DataContracts;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public class CommendationsViewModel
		: ViewModelBase
	{
		public CommendationsViewModel(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory, 
			CommendationsDetailsFull commendations, CommendationCategory commendationCategory)
			: base(serviceRecord, gameHistory)
		{
			Commendations = commendations;
			CommendationCategory = commendationCategory;
		}

		public CommendationsDetailsFull Commendations { get; set; }

		public CommendationCategory CommendationCategory { get; set; }
	}
}
