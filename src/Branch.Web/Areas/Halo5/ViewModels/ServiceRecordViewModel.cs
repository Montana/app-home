﻿using Branch.Service.Halo5.Models.Api;

namespace Branch.Web.Areas.Halo5.ViewModels
{
	public class ServiceRecordViewModel
		: ViewModelBase
	{
		public ServiceRecordViewModel(ServiceRecordStats arenaServiceRecord, ServiceRecordStats warzoneServiceRecord)
			: base(arenaServiceRecord, warzoneServiceRecord)
		{ }
	}
}