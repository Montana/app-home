using Microsoft.Xbox.Core.DataContracts.Enum;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts.Abstracts
{
	public abstract class Response
	{
		[JsonProperty("code")]
		public StatusCode StatusCode { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }
	}
}
