using System.ComponentModel;

namespace Microsoft.Halo.Core.DataContracts.Enums
{
	public enum Faction
	{
		[Description("UNSC")]
		Unsc = 0x00,

		[Description("Covenant")]
		Covenant = 0x01,

		[Description("Forerunner")]
		Forerunner = 0x02,

		[Description("None")]
		None = 0x03
	}
}
