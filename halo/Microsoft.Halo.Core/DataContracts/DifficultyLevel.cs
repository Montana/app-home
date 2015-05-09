using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Halo.Core.DataContracts
{
	public class DifficultyLevel
	{
		public uint Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public AssetContainer ImageUrl { get; set; }
	}
}
