using Branch.Service.Halo4.Models.Extentions;
using Microsoft.Halo.Core.DataContracts.Abstracts;
using Microsoft.Halo.Core.DataContracts.Enums;

namespace Branch.Service.Halo4.Extentions
{
	public static class GameHistoryExtentions
	{
		/// <summary>
		/// Gets the user friendly, and CSS friendly result of a <see cref="GameHistory"/> entry.
		/// </summary>
		/// <param name="gameHistory">The <see cref="GameHistory"/> entry in question.</param>
		/// <returns>A <see cref="GameVictoryStatusContainer"/> containing the user friendly, and CSS friendly results of the game.</returns>
		public static GameVictoryStatusContainer GetGameVictoryStatus(this GameHistory gameHistory)
		{
			var result = "Did Not Finish";
			var resultClass = "dnf";
			switch (gameHistory.Result)
			{
				case GameResult.Won:
					result = "Victory";
					resultClass = "victory";
					break;

				case GameResult.Lost:
					result = "Defeat";
					resultClass = "defeat";
					break;

				case GameResult.Draw:
					result = "Tie";
					resultClass = "dnf";
					break;
			}

			return new GameVictoryStatusContainer
			{
				UserFriendlyResult = result,
				CssFriendlyResult = resultClass
			};
		}
	}
}
