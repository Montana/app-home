using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class GameHistoryDetailsFull
		: Response
	{
		[JsonProperty("DateFidelity")]
		public uint DateFidelity { get; set; }

		[JsonProperty("Games")]
		public IReadOnlyCollection<GameHistory> Games { get; set; }
	}
}
