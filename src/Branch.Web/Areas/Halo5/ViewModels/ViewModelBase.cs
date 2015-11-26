using Branch.Service.Halo5.Models.Api;

namespace Branch.Web.Areas.Halo5.ViewModels
{
	public abstract class ViewModelBase
	{
		protected ViewModelBase(ServiceRecordStats arenaServiceRecord, ServiceRecordStats warzoneServiceRecord,
			ServiceRecordStats customsServiceRecord, ServiceRecordStats campaignServiceRecord,
			Response<MatchHistory> matchHistory)
		{
			arenaServiceRecord.WarzoneStats = warzoneServiceRecord.WarzoneStats;
			arenaServiceRecord.CustomsStats = warzoneServiceRecord.CustomsStats;
			arenaServiceRecord.CampaignStat = warzoneServiceRecord.CampaignStat;

			ServiceRecord = arenaServiceRecord;
			MatchHistory = matchHistory;
		}

		public ServiceRecordStats ServiceRecord { get; set; }

		public Response<MatchHistory> MatchHistory { get; set; }
	}
}
