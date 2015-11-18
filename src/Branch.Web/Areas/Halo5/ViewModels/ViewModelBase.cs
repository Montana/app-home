using Branch.Service.Halo5.Models.Api;

namespace Branch.Web.Areas.Halo5.ViewModels
{
	public abstract class ViewModelBase
	{
		protected ViewModelBase(ServiceRecordStats arenaServiceRecord, ServiceRecordStats warzoneServiceRecord)
		{
			arenaServiceRecord.WarzoneStats = warzoneServiceRecord.WarzoneStats;
			ServiceRecord = arenaServiceRecord;
		}

		public ServiceRecordStats ServiceRecord { get; set; }
	}
}
