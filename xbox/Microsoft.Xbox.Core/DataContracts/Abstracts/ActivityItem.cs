using System;
using Microsoft.Xbox.Core.DataContracts.Enum;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts.Abstracts
{
	public class ActivityItem
	{
		[JsonProperty("activityItemType")]
		public ActivityItemType ActivityItemType { get; set; }
		
		[JsonProperty("contentImageUri")]
		public string ContentImageUri { get; set; }

		[JsonProperty("bingId")]
		public string BingId { get; set; }

		[JsonProperty("contentTitle")]
		public string ContentTitle { get; set; }

		[JsonProperty("vuiDisplayName")]
		public string VuiDisplayName { get; set; }

		[JsonProperty("platform")]
		public string Platform { get; set; }

		[JsonProperty("titleId")]
		public string TitleId { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("hasUgc")]
		public bool HasUserGeneratedContent { get; set; }

		[JsonProperty("contentType")]
		public string ContentType { get; set; }

		[JsonProperty("shortDescription")]
		public string ShortDescription { get; set; }

		[JsonProperty("ugcCaption")]
		public string UserGeneratedContentCaption { get; set; }

		[JsonProperty("itemText")]
		public string ItemText { get; set; }

		[JsonProperty("itemImage")]
		public string ItemImage { get; set; }

		[JsonProperty("shareRoot")]
		public string ShareRoot { get; set; }

		[JsonProperty("feedItemId")]
		public string FeedItemId { get; set; }

		[JsonProperty("itemRoot")]
		public string ItemRoot { get; set; }

		[JsonProperty("numLikes")]
		public int LikeCount { get; set; }

		[JsonProperty("numComments")]
		public int CommentCount { get; set; }

		[JsonProperty("hasLiked")]
		public bool HasLiked { get; set; }

		[JsonProperty("authorInfo")]
		public AuthorInformtion AuthorInfo { get; set; }

		[JsonProperty("originalAuthorInfo")]
		public AuthorInformtion OriginalAuthorInfo { get; set; }

		[JsonProperty("userXuid")]
		public string UserXuid { get; set; }
		
		[JsonProperty("viewCount")]
		public Nullable<int> ViewCount { get; set; }

		[JsonProperty("numShares")]
		public Nullable<int> NumShares { get; set; }
	}
}
