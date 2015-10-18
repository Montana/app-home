using Branch.Helpers.DocumentDb;
using Branch.Helpers.Extentions;

namespace Branch.Service.XboxLive.DocumentDb
{
	public class XboxLiveDdbRepository
		: DocumentDbRepository
	{
		public XboxLiveDdbRepository()
			: base(Startup.Configuration.GetDefaultOrBackup(), "XboxLive")
		{ }
	}
}
