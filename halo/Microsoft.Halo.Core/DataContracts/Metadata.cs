using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class Metadata
		: Response
	{
		[JsonProperty("DifficultiesMetadata")]
		public DifficultiesMetadata DifficultiesMetadata { get; set; }

		[JsonProperty("MapsMetadata")]
		public MapsMetadata MapsMetadata { get; set; }

		[JsonProperty("CommendationsMetadata")]
		public CommendationsMetadata CommendationsMetadata { get; set; }

		[JsonProperty("PlaylistsMetadata")]
		public PlaylistsMetadata PlaylistsMetadata { get; set; }

		[JsonProperty("SpecializationsMetadata")]
		public SpecializationsMetadata SpecializationsMetadata { get; set; }
	}
}
