using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Branch.Web
{
	public class Startup
	{
		public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
		{
			// Setup configuration sources.
			var configuration = new ConfigurationBuilder()
				.SetBasePath(appEnv.ApplicationBasePath)
				.AddJsonFile("config.json")
				.AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

			if (env.IsEnvironment("Development"))
			{
				configuration.AddUserSecrets();
			}

			configuration.AddEnvironmentVariables();
			Configuration = configuration.Build();
			ApplicationEnviroment = appEnv;
		}

		public static IConfiguration Configuration { get; set; }

		public static IApplicationEnvironment ApplicationEnviroment { get; set; }

		public static IApplicationBuilder AppicationBuilder { get; set; }

		// This method gets called by the runtime.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

			// Add EntityFramework services to the services container.
			services.AddEntityFramework().AddSqlServer();

			// Add Xuid services to the services container.
			services.AddXuid();

			// Add Xbox Live services to the services container.
			services.AddXboxLive();

			// Add Halo 4 services to the services container.
			services.AddHalo4();

			// Add Halo 5 services to the services container.
			services.AddHalo5();

			// Add Mvc services to the services container.
			services.AddMvc();

			// Configure MVC routing
			services.ConfigureRouting(routeOptions =>
			{
				routeOptions.AppendTrailingSlash = true;
				routeOptions.LowercaseUrls = true;
			});
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
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// Add Error handling middleware which catches all application specific errors and
				// send the request to the following path or controller action.
				app.UseExceptionHandler("/Home/Error");
			}

			// Add Status Code Pages
			app.UseStatusCodePages();

			// Add Xuid
			app.UseXuid();

			// Add Xbox Live
			app.UseXboxLive();

			// Add Halo 4
			app.UseHalo4();

			// Add Halo 5
			app.UseHalo5();

			// Add static files to the request pipeline.
			app.UseStaticFiles();

			// Add MVC to the request pipeline.
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "GameRoute",
					template: "xbox/{gamertag}/{area:exists}/{controller=Home}/{action=Index}/{id?}");

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			AppicationBuilder = app;
		}
	}
}
