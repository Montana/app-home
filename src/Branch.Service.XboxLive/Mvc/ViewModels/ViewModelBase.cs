using Microsoft.Xbox.Core.DataContracts;

namespace Branch.Service.XboxLive.Mvc.ViewModels
{
	public abstract class ViewModelBase
	{
		public ViewModelBase(ProfileUser profileUser, ProfileSummary profileSummary,
			ActivityItems showcaseItems, PreferredColor preferredColor)
		{
			ProfileUser = profileUser;
			ProfileSummary = profileSummary;
			ShowcaseItems = showcaseItems;
			PreferredColors = preferredColor;
		}

		public ProfileUser ProfileUser { get; set; }

		public ProfileSummary ProfileSummary { get; set; }

		public ActivityItems ShowcaseItems { get; set; }

		public PreferredColor PreferredColors { get; set; }
	}
}
