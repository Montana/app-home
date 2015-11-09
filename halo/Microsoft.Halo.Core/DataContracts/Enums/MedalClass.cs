using System.ComponentModel;

namespace Microsoft.Halo.Core.DataContracts.Enums
{
	public enum MedalClass
	{
		[Description("Kill")]
		Kill = 0x00,

		[Description("Bonus / Style")]
		BonusOrStyle = 0x01,

		[Description("Assist / Support")]
		AssistOrSupport = 0x02,

		[Description("Spree")]
		Spree = 0x03,

		[Description("Mode Specific")]
		ModeSpecific = 0x04
	}
}
