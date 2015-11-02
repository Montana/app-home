using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CommendationsDetailsFull
		: Response
	{
		[JsonProperty("Commendations")]
		public IReadOnlyCollection<Commendation> Commendations { get; set; }
	}
}
