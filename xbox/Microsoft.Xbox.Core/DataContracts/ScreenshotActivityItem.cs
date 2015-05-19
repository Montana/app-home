using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class ScreenshotActivityItem
		: ActivityItem
	{
		[JsonProperty("screenshotId")]
		public string ScreenshotId { get; set; }

		[JsonProperty("screenshotThumbnail")]
		public string ScreenshotThumbnail { get; set; }

		[JsonProperty("screenshotScid")]
		public string ScreenshotScid { get; set; }

		[JsonProperty("screenshotName")]
		public string ScreenshotName { get; set; }

		[JsonProperty("screenshotUri")]
		public string ScreenshotUri { get; set; }
	}
}
