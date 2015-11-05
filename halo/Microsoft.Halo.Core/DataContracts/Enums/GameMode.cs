using System.ComponentModel;

namespace Microsoft.Halo.Core.DataContracts.Enums
{
	public enum GameMode
	{
		[Description("War Games")]
		WarGames = 0x03,

		[Description("Campaign")]
		Campaign = 0x04,

		[Description("Spartan Ops")]
		SpartanOps = 0x05,

		[Description("Custom Game")]
		CustomGame = 0x06
	}
}
