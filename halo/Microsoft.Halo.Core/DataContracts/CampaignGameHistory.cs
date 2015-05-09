using System;
using System.Collections.Generic;
using Microsoft.Halo.Core.DataContracts.Abstracts;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CampaignGameHistory
		: GameHistory
	{
		public AssetContainer DifficultyImageUrl { get; set; }

		public IReadOnlyCollection<uint> SkullIds { get; set; }

		public TimeSpan Duration { get; set; }
	}
}
