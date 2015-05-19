using System;
using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class GameDvrActivityItem
		: ActivityItem
	{
		[JsonProperty("clipId")]
		public string ClipId { get; set; }

		[JsonProperty("clipThumbnail")]
		public string ClipThumbnail { get; set; }

		[JsonProperty("clipName")]
		public string ClipName { get; set; }

		[JsonProperty("clipCaption")]
		public string ClipCaption { get; set; }

		[JsonProperty("clipScid")]
		public string ClipScid { get; set; }

		[JsonProperty("dateRecorded")]
		public DateTime DateRecorded { get; set; }
	}
}
