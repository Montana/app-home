using Branch.Helpers;
using Microsoft.AspNet.Mvc.Filters;
using System;

namespace Branch.Web.Attributes
{
	public class ServiceRequired : ActionFilterAttribute
	{
		public enum Service
		{
			Halo4,
			XboxLive
		}

		private Service _service;

		public ServiceRequired(Service service)
		{
			_service = service;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			try
			{
				switch (_service)
				{
					case Service.XboxLive:
						Startup.AppicationBuilder.GetService<Branch.Service.XboxLive.Services.UserService>();
						break;

					default:
						throw new NotImplementedException();
				}
			}
			catch (InvalidOperationException)
			{
				// TODO: handle this gracefully
				throw new NotImplementedException();
			}

			base.OnActionExecuting(context);
		}
	}
}
