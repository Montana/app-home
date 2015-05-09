using System;

namespace Microsoft.Halo.Core.DataContracts
{
	public class Promotion
	{
		public Guid Id { get; set; }

		public uint TypeId { get; set; }

		public uint LifetimeXP { get; set; }

		public uint LifetimeDoubleXP { get; set; }

		public uint TotalDoubleXpGames { get; set; }

		public uint TotalNormalXpGames { get; set; }
	}
}
