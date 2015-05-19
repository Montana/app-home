using System.Collections.Generic;
using Microsoft.Xbox.Core.Converters;
using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class ActivityItems
		: Response
	{
		[JsonProperty("activityItems")]
		[JsonConverter(typeof(ActivityItemConverter))]
		public IReadOnlyCollection<ActivityItem> Items { get; set; }

		[JsonProperty("contToken")]
		public string ContinuationToken { get; set; }

		[JsonProperty("numItems")]
		public uint ItemCount { get; set; }

		[JsonProperty("pollingToken")]
		public string PollingToken { get; set; }
	}
}
