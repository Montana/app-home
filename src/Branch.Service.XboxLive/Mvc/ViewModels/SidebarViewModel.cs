namespace Branch.Service.XboxLive.Mvc.ViewModels
{
	public enum SidebarOption
	{
		Showcase,
		Activity,
		Achievements,
		Following,
		GameClips
	}

	public class SidebarViewModel
	{
		public SidebarViewModel(string gamertag, SidebarOption sidebarOption)
		{
			Gamertag = gamertag;
			SidebarOption = sidebarOption;
		}

		public string Gamertag { get; set; }

		public SidebarOption SidebarOption { get; set; }
	}
}
