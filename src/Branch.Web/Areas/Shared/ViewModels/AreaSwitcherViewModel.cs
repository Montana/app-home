using Branch.Web.Areas.Shared.Enums;

namespace Branch.Web.Areas.Shared.ViewModels
{
	public class AreaSwitcherViewModel
	{
		public AreaSwitcherViewModel(string rgb, string @class, string backgroundImage, string gamertag, Area area)
		{
			Rgb = rgb;
			Class = @class;
			BackgroundImage = backgroundImage;
			Gamertag = gamertag;
			Area = area;
		}

		public string Rgb { get; set; }

		public string Class { get; set; }

		public string BackgroundImage { get; set; }

		public string Gamertag { get; set; }

		public Area Area { get; set; }
	}
}
