using System;
using Microsoft.AspNet.Builder;

namespace Branch.Helpers
{
	public static class ApplicationBuilderExtentions
	{
		public static T GetService<T>(this IApplicationBuilder applicationBuilder)
			where T : class
		{
			var type = typeof(T);
			var service = applicationBuilder.ApplicationServices.GetService(typeof(T)) as T;
			if (service == null)
				throw new InvalidOperationException($"The {type.Namespace}.{type.Name} service has not been registered.");

			return service;
		}
	}
}
