using System.Diagnostics;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;

namespace Branch.Web.Filters
{
	public class ActionTimerAttribute : ActionFilterAttribute
	{
		public ActionTimerAttribute()
		{
			Order = int.MaxValue;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var controller = filterContext.Controller as Controller;
			if (controller != null)
			{
				var timer = new Stopwatch();
				controller.ViewData["_ActionTimer"] = timer;
				timer.Start();
			}
			base.OnActionExecuting(filterContext);
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var controller = filterContext.Controller as Controller;
			var timer = (Stopwatch)controller?.ViewData["_ActionTimer"];
			if (timer == null) return;

			timer.Stop();
			controller.ViewData["_ElapsedTime"] = timer.ElapsedMilliseconds;
		}
	}
}