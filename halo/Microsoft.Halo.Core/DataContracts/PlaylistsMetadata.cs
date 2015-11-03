using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class PlaylistsMetadata
	{
		[JsonProperty("Playlists")]
		public IReadOnlyCollection<PlaylistDetailsFull> Playlists { get; set; }
	}
}
