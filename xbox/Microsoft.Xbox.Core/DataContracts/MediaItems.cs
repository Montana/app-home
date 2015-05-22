using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class MediaItems
		: Response
	{
		[JsonProperty("ImpressionGuid")]
		public string ImpressionGuid { get; set; }

		[JsonProperty("Items")]
		public IReadOnlyCollection<MediaItem> Items { get; set; }
	}
}
