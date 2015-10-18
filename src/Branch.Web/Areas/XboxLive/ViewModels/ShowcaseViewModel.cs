using Microsoft.Xbox.Core.DataContracts;

namespace Branch.Web.Areas.XboxLive.ViewModels
{
	public class ShowcaseViewModel
		: ViewModelBase
	{
		public ShowcaseViewModel(ProfileUser profileUser, ProfileSummary profileSummary,
			ActivityItems showcaseItems, PreferredColor preferredColor)
			: base(profileUser, profileSummary, preferredColor)
		{
			ShowcaseItems = showcaseItems;
		}

		public ActivityItems ShowcaseItems { get; set; }
	}
}
