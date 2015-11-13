using Branch.Service.Halo5.Models.Api.Abstracts;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class ServiceRecordDetailsFull : Result
	{
		[JsonProperty("ArenaStats")]
		public ArenaServiceRecordDetailsFull ArenaServiceRecordStats { get; set; }
	}
}
