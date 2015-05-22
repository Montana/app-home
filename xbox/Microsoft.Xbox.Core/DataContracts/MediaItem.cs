using Microsoft.Xbox.Core.DataContracts.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class MediaItem
	{
		[JsonProperty("MediaGroup")]
		public string MediaGroup { get; set; }

		[JsonProperty("MediaItemType")]
		public string MediaItemType { get; set; }

		[JsonProperty("ID")]
		public string ID { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("ReducedDescription")]
		public string ReducedDescription { get; set; }

		[JsonProperty("ReleaseDate")]
		public DateTime ReleaseDate { get; set; }

		[JsonProperty("TitleId")]
		public UInt32 TitleId { get; set; }

		[JsonProperty("Genres")]
		public IReadOnlyCollection<MediaGenre> Genres { get; set; }

		[JsonProperty("DeveloperName")]
		public string DeveloperName { get; set; }

		[JsonProperty("Images")]
		public IReadOnlyCollection<MediaImage> Images { get; set; }

		[JsonProperty("PublisherName")]
		public string PublisherName { get; set; }

		[JsonProperty("Capabilities")]
		public IReadOnlyCollection<MediaCapability> Capabilities { get; set; }

		[JsonProperty("KValue")]
		public string KValue { get; set; }

		[JsonProperty("KValueNamespace")]
		public string KValueNamespace { get; set; }

		[JsonProperty("RelatedMedia")]
		public IReadOnlyCollection<RelatedMedia> RelatedMedia { get; set; }

		[JsonProperty("AllTimeRatingCount")]
		public double AllTimeRatingCount { get; set; }

		[JsonProperty("AllTimeAverageRating")]
		public double AllTimeAverageRating { get; set; }

		[JsonProperty("Availabilities")]
		public IReadOnlyCollection<MediaAvailability> Availabilities { get; set; }

		[JsonProperty("ParentalRatings")]
		public IReadOnlyCollection<ParentalRating> ParentalRatings { get; set; }

		[JsonProperty("IsPartOfAnyBundle")]
		public bool? IsPartOfAnyBundle { get; set; }
	}
}
