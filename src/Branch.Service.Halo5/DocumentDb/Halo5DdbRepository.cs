using Branch.Helpers.DocumentDb;
using Branch.Helpers.Extentions;

namespace Branch.Service.Halo5.DocumentDb
{
	public class Halo5DdbRepository
		: DocumentDbRepository
	{
		public Halo5DdbRepository()
			: base(Startup.Configuration.GetDefaultOrBackup(), "Halo4")
		{ }
	}
}
