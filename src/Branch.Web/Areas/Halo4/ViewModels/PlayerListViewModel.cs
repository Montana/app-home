using Microsoft.Halo.Core.DataContracts;
using System.Collections.Generic;

namespace Branch.Web.Areas.Halo4.ViewModels
{
	public class PlayerListViewModel
	{
		public PlayerListViewModel(ServiceRecordDetailsFull serviceRecordDetails, GameTeam team, IEnumerable<GamePlayer> gamePlayers)
		{
			ServiceRecordDetails = serviceRecordDetails;
			Team = team;
			GamePlayers = gamePlayers;
		}

		public ServiceRecordDetailsFull ServiceRecordDetails { get; set; }

		public GameTeam Team { get; set; }

		public IEnumerable<GamePlayer> GamePlayers { get; set; }
	}
}
