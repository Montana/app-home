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
			Halo5,
			XboxLive
		}

		private readonly Service _service;

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

					case Service.Halo4:
						Startup.AppicationBuilder.GetService<Branch.Service.Halo4.Services.ServiceRecordService>();
						break;

					case Service.Halo5:
						Startup.AppicationBuilder.GetService<Branch.Service.Halo5.Services.ServiceRecordService>();
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
