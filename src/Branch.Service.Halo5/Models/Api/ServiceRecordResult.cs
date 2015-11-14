using Branch.Service.Halo5.Models.Api.Abstracts;
using Branch.Service.Halo5.Models.Api.Enums;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ServiceRecordResult
		: Result
	{
		[JsonProperty("Id")]
		public string Id { get; set; }

		[JsonProperty("ResultCode")]
		public ResultCode ResultCode { get; set; }

		[JsonProperty("Result")]
		public ServiceRecordStats Result { get; set; }
	}
}
