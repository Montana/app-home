using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpartanOpsVideoDetailsFull
	{
		[JsonProperty("Language")]
		public string Language { get; set; }

		[JsonProperty("Folder")]
		public string Folder { get; set; }

		[JsonProperty("WebFileName")]
		public string WebFileName { get; set; }

		[JsonProperty("ConsoleFileName")]
		public string ConsoleFileName { get; set; }

		[JsonProperty("MobileFileName")]
		public string MobileFileName { get; set; }

		[JsonProperty("IosFileName")]
		public string IosFileName { get; set; }

		[JsonProperty("IosSuffix")]
		public string IosSuffix { get; set; }

		[JsonProperty("Mp4FileName")]
		public string Mp4FileName { get; set; }

		[JsonProperty("Mp4Suffix")]
		public string Mp4Suffix { get; set; }
	}
}
