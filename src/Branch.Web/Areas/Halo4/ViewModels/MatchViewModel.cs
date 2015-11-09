using Microsoft.Halo.Core.DataContracts;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public class MatchViewModel<T>
		: ViewModelBase
		where T : GameDetails
	{
		public MatchViewModel(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory, GameDetails matchDetails, GameMode gameMode)
			: base(serviceRecord, gameHistory)
		{
			MatchDetails = matchDetails as T;
			GameMode = gameMode;
		}
		
		public T MatchDetails { get; set; }

		public GameMode GameMode { get; set; }
	}
}
