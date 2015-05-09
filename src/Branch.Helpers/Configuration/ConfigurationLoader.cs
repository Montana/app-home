using Microsoft.Framework.ConfigurationModel;

namespace Branch.Helpers.Configuration
{
	public static class ConfigurationLoader
	{
		public static IConfiguration Retrieve()
		{
			return new Microsoft.Framework.ConfigurationModel.Configuration()
				.AddUserSecrets()
				.AddEnvironmentVariables();
		}
	}
}
