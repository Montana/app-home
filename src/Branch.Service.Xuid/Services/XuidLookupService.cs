using System;
using Branch.Helpers.Services;
using Branch.Service.Xuid.Database;
using Microsoft.Framework.Logging;

namespace Branch.Service.Xuid.Services
{
	public class XuidLookupService
		: ServiceBase<XuidLookupService>
	{
		public XuidLookupService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidDbContext xuidDbContext, AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, xuidDbContext, authenticationService)
		{ }

		public long Lookup(string gamertag)
		{
			throw new NotImplementedException();
			// throw new PlayerDoesntExistException();
			return 0L;
		}
	}
}
