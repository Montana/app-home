using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;

namespace Branch.Helpers.Extentions
{
	public static class ConfigurationExtentions
	{
		public static IConfiguration GetDefaultOrBackup(this IConfiguration configuration)
		{
			var appEnv = CallContextServiceLocator.Locator.ServiceProvider.GetService(typeof(IApplicationEnvironment)) as IApplicationEnvironment;

			return configuration ?? new ConfigurationBuilder()
				.SetBasePath(appEnv.ApplicationBasePath)
				.AddUserSecrets()
				.AddEnvironmentVariables()
				.Build();
		}
	}
}
