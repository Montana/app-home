using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class LocalizedParentalRatingDetails
	{
		[JsonProperty("LongName")]
		public string LongName { get; set; }

		[JsonProperty("RatingImages")]
		public IReadOnlyCollection<LocalizedParentalRatingImages> RatingImages { get; set; }

		[JsonProperty("ShortName")]
		public string ShortName { get; set; }
	}
}
