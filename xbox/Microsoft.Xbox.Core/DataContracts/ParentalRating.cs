using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class ParentalRating
	{
		[JsonProperty("LegacyRatingId")]
		public int LegacyRatingId { get; set; }

		[JsonProperty("LocalizedDetails")]
		public LocalizedParentalRatingDetails LocalizedDetails { get; set; }

		[JsonProperty("Rating")]
		public string Rating { get; set; }

		[JsonProperty("RatingId")]
		public string RatingId { get; set; }

		[JsonProperty("RatingMinimimAge")]
		public int RatingMinimimAge { get; set; }

		[JsonProperty("RatingSystem")]
		public string RatingSystem { get; set; }
	}
}
