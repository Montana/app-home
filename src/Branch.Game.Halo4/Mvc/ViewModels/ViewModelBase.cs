using Microsoft.Halo.Core.DataContracts;

namespace Branch.Game.Halo4.Mvc.ViewModels
{
	public abstract class ViewModelBase
	{
		public ViewModelBase(ServiceRecordDetailsFull serviceRecord)
		{
			ServiceRecord = serviceRecord;
		}

		public ServiceRecordDetailsFull ServiceRecord { get; set; }
	}
}
