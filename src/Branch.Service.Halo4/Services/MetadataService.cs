using Branch.Helpers.Services;
using Branch.Service.Halo4.Database;
using Branch.Service.Halo4.DocumentDb;
using Branch.Service.Xuid.Services;
using Microsoft.Framework.Logging;
using System;
using System.Threading.Tasks;

namespace Branch.Service.Halo4.Services
{
	public class MetadataService
		: ServiceBase<MetadataService>
	{
		public MetadataService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, Halo4DbContext halo4DbContext, Halo4DdbRepository halo4DdbRepository, AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{

		}

		private const string GetServiceRecordUrl = "https://stats.svc.halowaypoint.com/en-US/players/{0}/h4/servicerecord";

		private readonly TimeSpan CacheRefreshTime = new TimeSpan(12, 0, 0);

		// TODO
		// get metadata
		// get metadata section?
	}
}
