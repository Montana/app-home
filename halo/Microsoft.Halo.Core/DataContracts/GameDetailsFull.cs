using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class GameDetailsFull
		: Response
	{
		[JsonProperty("DateFidelity")]
		public int DateFidelity { get; set; }

		[JsonProperty("Game")]
		public GameDetails Game { get; set; }
	}
}
