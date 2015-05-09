using Microsoft.Azure.Documents;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	public abstract class Response
		: Document
	{
		public StatusCode StatusCode { get; set; }

		public string StatusReason { get; set; }
	}
}
