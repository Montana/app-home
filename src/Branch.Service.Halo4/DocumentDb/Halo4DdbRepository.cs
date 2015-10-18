using Branch.Helpers.DocumentDb;
using Branch.Helpers.Extentions;

namespace Branch.Service.Halo4.DocumentDb
{
	public class Halo4DdbRepository
		: DocumentDbRepository
	{
		public Halo4DdbRepository()
			: base(Startup.Configuration.GetDefaultOrBackup(), "Halo4")
		{ }
	}
}
