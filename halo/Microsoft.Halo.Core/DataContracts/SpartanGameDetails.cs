using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpartanGameDetails
		: GameDetails
	{
		[JsonProperty("ChapterId")]
		public int ChapterId { get; set; }
		
		[JsonProperty("Difficulty")]
		public Difficulty Difficulty { get; set; }

		[JsonProperty("SinglePlayer")]
		public bool SinglePlayer { get; set; }
	}
}
