using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Runtime;

namespace Branch.Web
{
	public class Startup
	{
		public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
		{
			// Setup configuration sources.
			var configuration = new Configuration()
				.AddJsonFile("config.json")
				.AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

			if (env.IsEnvironment("Development"))
			{
				configuration.AddUserSecrets();
			}

			configuration.AddEnvironmentVariables();
			Configuration = configuration;
			ApplicationEnviroment = appEnv;
		}

		public IConfiguration Configuration { get; set; }

		public IApplicationEnvironment ApplicationEnviroment { get; set; }

		// This method gets called by the runtime.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<AppSettings>(Configuration.GetSubKey("AppSettings"));
			
			// Add EntityFramework services to the services container.
			services.AddEntityFramework().AddSqlServer();

			// Add MVC services to the services container.
			services.AddMvc().ConfigureRazorViewEngine(options =>
			{
				var oldRoot = ApplicationEnviroment.ApplicationBasePath;
				var trimmedRoot = oldRoot.Remove(oldRoot.LastIndexOf('\\'));

				options.FileProvider = new PhysicalFileProvider(trimmedRoot);
			});

			// Add Xbox Live services to the services container.
			services.AddXboxLive();
			
			// Add Halo 4 services to the services container.
			services.AddHalo4();
		}

		// Configure is called after ConfigureServices is called.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
		{
			// Add the console logger.
			loggerfactory.AddConsole();
			
			// Add the following to the request pipeline only in development environment.
			if (env.IsEnvironment("Development"))
			{
				app.UseBrowserLink();
				app.UseErrorPage(ErrorPageOptions.ShowAll);
			}
			else
			{
				// Add Error handling middleware which catches all application specific errors and
				// send the request to the following path or controller action.
				app.UseErrorHandler("/Home/Error");
			}

			// Add Status Code Pages
			app.UseStatusCodePages();

			// Add Xbox Live
			app.UseXboxLive();

			// Add Halo 4
			app.UseHalo4();

			// Add static files to the request pipeline.
			app.UseStaticFiles();
			
			// Add MVC to the request pipeline.
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "GameRoute",
					template: "Xbox/{gamertag}/{area:exists}/{controller=Home}/{action=Index}/{id?}");

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
