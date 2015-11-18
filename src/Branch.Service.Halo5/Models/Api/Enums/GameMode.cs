using System.ComponentModel;

namespace Branch.Service.Halo5.Models.Api.Enums
{
	public enum GameMode
	{
		[Description("Error")]
		Error = 0x00,

		[Description("Arena")]
		Arena = 0x01,

		[Description("Campaign")]
		Campaign = 0x02,

		[Description("Custom Games")]
		CustomGames = 0x03,

		[Description("Warzone")]
		Warzone = 0x04
	}
}
