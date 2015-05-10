using System;
using System.Runtime.Serialization;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class Promotion
	{
		[DataMember(Name = "Id")]
		public Guid Id { get; set; }

		[DataMember(Name = "TypeId")]
		public uint TypeId { get; set; }

		[DataMember(Name = "LifetimeXP")]
		public uint LifetimeXP { get; set; }

		[DataMember(Name = "LifetimeDoubleXP")]
		public uint LifetimeDoubleXP { get; set; }

		[DataMember(Name = "TotalDoubleXpGames")]
		public uint TotalDoubleXpGames { get; set; }

		[DataMember(Name = "TotalNormalXpGames")]
		public uint TotalNormalXpGames { get; set; }
	}
}
