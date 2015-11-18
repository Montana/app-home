using Newtonsoft.Json;
using System;

namespace Branch.Service.Halo5.Models.Api
{
	public class UniversalDateTimeContainer
	{
		[JsonProperty("ISO8601Date")]
		public DateTime ISO8601Date { get; set; }
	}
}
