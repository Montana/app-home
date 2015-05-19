using Branch.Helpers.Configuration;
using Branch.Helpers.DocumentDb;

namespace Branch.Service.XboxLive.DocumentDb
{
	public class XboxLiveDdbRepository
		: DocumentDbRepository
	{
		public XboxLiveDdbRepository()
			: base(ConfigurationLoader.Retrieve().GetSubKey("XboxLive"))
		{ }
	}
}
