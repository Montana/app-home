using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class UserTitleHistory<T>
		: Response
		where T : UserTitle
	{
		[JsonProperty("pagingInfo")]
		public PagingInfo PagingInfo { get; set; }

		[JsonProperty("titles")]
		public IReadOnlyCollection<T> Titles { get; set; }
	}
}
