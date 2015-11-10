using System.ComponentModel;

namespace Microsoft.Halo.Core.DataContracts.Enums
{
	public enum MedalTier
	{
		[Description("Suppport")]
		Support = 0x00,

		[Description("Kill")]
		Kill = 0x01,

		[Description("Bronze")]
		Bronze = 0x02,

		[Description("Silver")]
		Silver = 0x03,

		[Description("Gold")]
		Gold = 0x04,

		[Description("Platinum")]
		Platinum = 0x05,

		[Description("Onyx")]
		Onyx = 0x06
	}
}
