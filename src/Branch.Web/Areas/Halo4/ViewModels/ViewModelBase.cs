using Microsoft.Halo.Core.DataContracts;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public abstract class ViewModelBase
	{
		public ViewModelBase(ServiceRecord serviceRecord)
		{
			ServiceRecord = serviceRecord;
		}

		public ServiceRecord ServiceRecord { get; set; }
	}
}
