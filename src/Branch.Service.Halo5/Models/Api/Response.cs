using System.Collections.Generic;
using Branch.Service.Halo5.Models.Api.Abstracts;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class Response<T>
		: Document
		where T : Result
	{
		[JsonProperty("Start")]
		public int Start { get; set; }

		[JsonProperty("Count")]
		public int Count { get; set; }

		[JsonProperty("ResultCount")]
		public int ResultCount { get; set; }

		[JsonProperty("Results")]
		public IReadOnlyCollection<T> Results { get; set; }
	}
}
