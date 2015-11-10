using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class FactionsMetadata
	{
		[JsonProperty("Factions")]
		public IReadOnlyCollection<FactionDetailsFull> Factions { get; set; }
	}
}
