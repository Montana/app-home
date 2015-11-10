using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class MedalsMetadata
	{
		[JsonProperty("Medals")]
		public IReadOnlyCollection<MedalDetailsFull> Medals { get; set; }

		[JsonProperty("MedalClasses")]
		public IReadOnlyCollection<MedalClassDetailsFull> MedalClasses { get; set
				; }
		[JsonProperty("MedalTiers")]
		public IReadOnlyCollection<MedalTierDetailsFull> MedalTiers { get; set; }
	}
}
