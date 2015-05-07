using Branch.Game.Halo4.Models.Services;
using Branch.Game.Halo4.Services;
using Branch.Helpers;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.Logging;

namespace Microsoft.AspNet.Builder
{
	/// <summary>
	/// Extension methods for <see cref="IApplicationBuilder"/> to add Branch.Game.Halo4 to the request execution pipeline.
	/// </summary>
	public static class BuilderExtentions
	{
		/// <summary>
		/// Adds Branch.Game.Halo4 to the <see cref="IApplicationBuilder"/> request execution pipeline.
		/// </summary>
		public static IApplicationBuilder UseHalo4(
			this IApplicationBuilder app, ILoggerFactory loggerFactory, IConfiguration configuration)
		{
			app.GetService<AuthenticationService>().RegisterService<AuthenticationService>(loggerFactory, new Halo4AuthenticationOptions
			{
				MicrosoftAccount = configuration.Get("Authentication:MicrosoftAccount"),
				MicrosoftAccountPassword = configuration.Get("Authentication:MicrosoftAccountPassword"),
				ApiEndpoint = configuration.Get("Authentication:ApiEndpoint")
			});
			app.GetService<ProfileService>().RegisterService<ProfileService>(loggerFactory);

			return app;
		}
	}
}
