using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class MapsMetadata
	{
		[JsonProperty("Maps")]
		public IReadOnlyCollection<MapDetailsFull> Maps { get; set; }
	}
}
