﻿namespace Branch.Web.Areas.Halo4.ViewModels
{
	public enum SidebarOption
	{
		ServiceRecord,
		MatchHistory,
		CompetitiveSkillRanking,
		Commendations,
		Specializations
	}

	public class SidebarViewModel
	{
		public SidebarViewModel(string gamertag, SidebarOption sidebarOption, object sidebarSubOption = null)
		{
			Gamertag = gamertag;
			SidebarOption = sidebarOption;
			SidebarSubOption = sidebarSubOption ?? -1;
		}

		public string Gamertag { get; set; }

		public SidebarOption SidebarOption { get; set; }

		public object SidebarSubOption { get; set; }
	}
}