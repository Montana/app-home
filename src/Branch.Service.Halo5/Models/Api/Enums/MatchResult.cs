using System.ComponentModel;

namespace Branch.Service.Halo5.Models.Api.Enums
{
	public enum MatchResult
	{
		[Description("Did Not Finish")]
		DidNotFinish = 0x00,

		[Description("Defeat")]
		Lost = 0x01,

		[Description("Tied")]
		Tied = 0x02,

		[Description("Victory")]
		Won = 0x03
	}
}
