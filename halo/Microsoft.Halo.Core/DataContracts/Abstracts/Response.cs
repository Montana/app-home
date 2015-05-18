using Microsoft.Azure.Documents;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	public abstract class Response
		: Document
	{
		[JsonProperty("StatusCode")]
		public StatusCode StatusCode { get; set; }

		[JsonProperty("StatusReason")]
		public string StatusReason { get; set; }
	}
}
