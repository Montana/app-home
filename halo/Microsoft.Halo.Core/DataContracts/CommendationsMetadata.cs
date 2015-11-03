using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
    public class CommendationsMetadata
    {
		[JsonProperty("Commendations")]
		public IList<CommendationDetailsFull> Commendations { get; set; }

		[JsonProperty("CommendationCategories")]
		public IList<CommendationCategoryDetailsFull> CommendationCategories { get; set; }

		[JsonProperty("CommendationLevels")]
		public IList<CommendationLevelDetailsFull> CommendationLevels { get; set; }
	}
}
