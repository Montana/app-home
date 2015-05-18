﻿using Microsoft.Halo.Core.DataContracts;

namespace Branch.Game.Halo4.Mvc.ViewModels
{
	public class ServiceRecordViewModel
		: ViewModelBase
	{
		public ServiceRecordViewModel(ServiceRecordDetailsFull serviceRecord, GameHistoryDetailsFull gameHistory)
			: base(serviceRecord)
		{
			GameHistory = gameHistory;
		}

		public GameHistoryDetailsFull GameHistory { get; set; }
	}
}
