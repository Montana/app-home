﻿using System;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ImpulseCountStatistic
	{
		[JsonProperty("Id")]
		public Int64 Id { get; set; }

		[JsonProperty("Count")]
		public int Count { get; set; }
	}
}
