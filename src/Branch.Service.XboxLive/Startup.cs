using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;

namespace Branch.Service.XboxLive
{
	public class Startup
	{
		public static IConfiguration Configuration { get; set; }

		public Startup(IApplicationEnvironment app, IHostingEnvironment env)
		{
			Configuration = new ConfigurationBuilder()
				.SetBasePath(app.ApplicationBasePath)
				.AddUserSecrets()
				.AddEnvironmentVariables()
				.Build();
		}

		public void Configure(IApplicationBuilder app)
		{

		}
	}
}
