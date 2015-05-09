using Branch.Helpers.Configuration;
using Branch.Helpers.DocumentDb;

namespace Branch.Game.Halo4.DocumentDb
{
	public class Halo4DdbRepository
		: DocumentDbRepository
	{
		public Halo4DdbRepository()
			: base(ConfigurationLoader.Retrieve().GetSubKey("Halo4"))
		{

		}
	}
}
