using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;

namespace Branch.Service.Halo5
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
