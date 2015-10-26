using Microsoft.Halo.Core.DataContracts.Abstracts;

namespace Branch.Service.Halo4.Models.Extentions
{
	public class GameVictoryStatusContainer
	{
		/// <summary>
		/// The user friendly result of a <see cref="GameHistory"/>. For example "Did Not Finish".
		/// </summary>
		public string UserFriendlyResult { get; set; }

		/// <summary>
		/// The css friendly result of a <see cref="GameHistory"/>. For example "dnf".
		/// </summary>
		public string CssFriendlyResult { get; set; }
	}
}
