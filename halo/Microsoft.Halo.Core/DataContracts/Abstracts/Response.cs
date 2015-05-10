using System.Runtime.Serialization;
using Microsoft.Azure.Documents;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts.Abstracts
{
	[DataContract]
	public abstract class Response
		: Document
	{
		[DataMember(Name = "StatusCode")]
		public StatusCode StatusCode { get; set; }

		[DataMember(Name = "StatusReason")]
		public string StatusReason { get; set; }
	}
}
