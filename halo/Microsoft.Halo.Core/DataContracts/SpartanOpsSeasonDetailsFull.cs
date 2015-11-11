using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpartanOpsSeasonDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Episodes")]
		public IList<SpartanOpsEpisodeDetailsFull> Episodes { get; set; }

		[JsonProperty("Epilogue")]
		public SpartanOpsEpilogueDetailsFull Epilogue { get; set; }
	}
}
