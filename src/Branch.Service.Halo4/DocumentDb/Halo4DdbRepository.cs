using Branch.Helpers.Configuration;
using Branch.Helpers.DocumentDb;
using Newtonsoft.Json;

namespace Branch.Service.Halo4.DocumentDb
{
	public class Halo4DdbRepository
		: DocumentDbRepository
	{
		public Halo4DdbRepository()
			: base(ConfigurationLoader.Retrieve().GetSubKey("Halo4"))
		{ }
	}
}
