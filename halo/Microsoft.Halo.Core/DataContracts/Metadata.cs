using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class Metadata
		: Response
	{
		[JsonProperty("MapsMetadata")]
		public MapsMetadata MapsMetadata { get; set; }

		[JsonProperty("CommendationsMetadata")]
		public CommendationsMetadata CommendationsMetadata { get; set; }

		[JsonProperty("PlaylistsMetadata")]
		public PlaylistsMetadata PlaylistsMetadata { get; set; }
	}
}
