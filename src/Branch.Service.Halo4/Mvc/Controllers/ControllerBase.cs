﻿using Branch.Service.Halo4.Services;
using Microsoft.AspNet.Mvc;

namespace Branch.Service.Halo4.Mvc.Controllers
{
	[Route("Xbox/{gamertag}/Halo4/")]
	public class ControllerBase : Controller
	{
		[FromServices]
		public ServiceRecordService ServiceRecordService { get; set; }
	}
}