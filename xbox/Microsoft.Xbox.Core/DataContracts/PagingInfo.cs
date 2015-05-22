using Newtonsoft.Json;
using System;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class PagingInfo
	{
		[JsonProperty("continuationToken")]
		public string ContinuationToken { get; set; }

		[JsonProperty("totalRecords")]
		public Int32 TotalRecords { get; set; }
	}
}
