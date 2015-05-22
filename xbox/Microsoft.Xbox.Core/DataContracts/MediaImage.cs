using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class MediaImage
	{
		[JsonProperty("ID")]
		public string Id { get; set; }

		[JsonProperty("Url")]
		public string Url { get; set; }

		[JsonProperty("ResizeUrl")]
		public string ResizeUrl { get; set; }

		[JsonProperty("Purposes")]
		public IReadOnlyCollection<string> Purposes { get; set; }

		[JsonProperty("Purpose")]
		public string Purpose { get; set; }

		[JsonProperty("Height")]
		public int Height { get; set; }

		[JsonProperty("Width")]
		public int Width { get; set; }

		[JsonProperty("Order")]
		public int? Order { get; set; }
	}
}
