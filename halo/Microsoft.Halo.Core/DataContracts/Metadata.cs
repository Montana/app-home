using Microsoft.Halo.Core.DataContracts.Abstracts;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class Metadata
		: Response
	{
		public MapsMetadata MapsMetadata { get; set; }
	}
}
