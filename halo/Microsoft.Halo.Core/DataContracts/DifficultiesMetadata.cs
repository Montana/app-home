using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class DifficultiesMetadata
	{
		[JsonProperty("Difficulties")]
		public IList<DifficultyDetailsFull> Difficulties { get; set; }
	}
}
