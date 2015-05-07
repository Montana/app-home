using System.Threading.Tasks;
using Branch.Helpers.Services;
using Microsoft.Framework.Logging;

namespace Branch.Game.Halo4.Services
{
	public class ProfileService
		: ServiceBase
	{
		public ProfileService(HttpManagerService httpManagerService, AuthenticationService authenticationService)
			: base(httpManagerService, authenticationService)
		{ }

		public async Task<string> GetTestAsync()
		{
			return await AuthenticationService.GetSpartanTokenAsync();
		}
	}
}
