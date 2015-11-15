﻿using System;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class MedalCountStatistic
	{
		[JsonProperty("Id")]
		public Guid Id { get; set; }

		[JsonProperty("Count")]
		public int Count { get; set; }
	}
}
