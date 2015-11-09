using System.ComponentModel;

namespace Microsoft.Halo.Core.DataContracts.Enums
{
	public enum GameResult
	{
		[Description("Lost")]
		Lost = 0,

		[Description("Draw")]
		Draw = 1,

		[Description("Won")]
		Won = 2
	}
}
