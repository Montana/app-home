using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
    public class CommendationsMetadata
    {
		[JsonProperty("Commendations")]
		public IList<CommendationMetadata> Commendations { get; set; }

		[JsonProperty("CommendationCategories")]
		public IList<CommendationCategoryMetadata> CommendationCategories { get; set; }

		[JsonProperty("CommendationLevels")]
		public IList<CommendationLevelMetadata> CommendationLevels { get; set; }
	}
}
