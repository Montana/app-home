using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.ViewModels
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
