namespace Microsoft.AspNet.Builder
{
	/// <summary>
	/// Extension methods for <see cref="IApplicationBuilder"/> to add Branch.Service.Xuid to the request execution pipeline.
	/// </summary>
	public static class BuilderExtentions
	{
		/// <summary>
		/// Adds Branch.Service.Xuid to the <see cref="IApplicationBuilder"/> request execution pipeline.
		/// </summary>
		public static IApplicationBuilder UseXuid(
			this IApplicationBuilder app)
		{
			return app;
		}
	}
}
