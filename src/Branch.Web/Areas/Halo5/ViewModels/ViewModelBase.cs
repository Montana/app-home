using Branch.Service.Halo5.Models.Api;

namespace Branch.Web.Areas.Halo5.ViewModels
{
	public abstract class ViewModelBase
	{
		public ViewModelBase(ArenaServiceRecordStats arenaServiceRecord)
		{
			ArenaServiceRecord = arenaServiceRecord;
		}

		public ArenaServiceRecordStats ArenaServiceRecord { get; set; }
	}
}
