using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpecializationsMetadata
	{
		[JsonProperty("Specializations")]
		public IReadOnlyCollection<SpecializationDetailsFull> Specializations { get; set; }

		[JsonProperty("SpecializationLevels")]
		public IList<SpecializationLevelDetailsFull> SpecializationLevels { get; set; }
	}
}
