namespace Microsoft.AspNet.Builder
{
	/// <summary>
	/// Extension methods for <see cref="IApplicationBuilder"/> to add Branch.Service.XboxLive to the request execution pipeline.
	/// </summary>
	public static class BuilderExtentions
	{
		/// <summary>
		/// Adds Branch.Service.XboxLive to the <see cref="IApplicationBuilder"/> request execution pipeline.
		/// </summary>
		public static IApplicationBuilder UseXboxLive(
			this IApplicationBuilder app)
		{
			return app;
		}
	}
}
