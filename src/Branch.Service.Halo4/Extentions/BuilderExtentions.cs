﻿namespace Microsoft.AspNet.Builder
{
	/// <summary>
	/// Extension methods for <see cref="IApplicationBuilder"/> to add Branch.Service.Halo4 to the request execution pipeline.
	/// </summary>
	public static class BuilderExtentions
	{
		/// <summary>
		/// Adds Branch.Service.Halo4 to the <see cref="IApplicationBuilder"/> request execution pipeline.
		/// </summary>
		public static IApplicationBuilder UseHalo4(
			this IApplicationBuilder app)
		{
			return app;
		}
	}
}
