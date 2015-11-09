using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class GameBaseVariantsMetadata
	{
		[JsonProperty("GameBaseVariants")]
		public IReadOnlyCollection<GameBaseVariantDetailsFull> GameBaseVariants { get; set; }
	}
}
