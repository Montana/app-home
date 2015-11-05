using System.ComponentModel;

namespace Microsoft.Halo.Core.DataContracts.Enums
{
	public enum CommendationCategory
	{
		[Description("Weapons")]
		Weapons = 0x01,

		[Description("Enemies")]
		Enemies = 0x03,

		[Description("Vehicles")]
		Vehicles = 0x04,

		[Description("Player")]
		Player = 0x05,

		[Description("Game Types")]
		GameTypes = 0x07
	}
}
