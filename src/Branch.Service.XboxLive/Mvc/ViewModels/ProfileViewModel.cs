using Microsoft.Xbox.Core.DataContracts;

namespace Branch.Service.XboxLive.Mvc.ViewModels
{
	public class ProfileViewModel
		: ViewModelBase
	{
		public ProfileViewModel(ProfileUser profileUser, ProfileSummary profileSummary, 
			ActivityItems showcaseItems, PreferredColor preferredColor)
			: base(profileUser, profileSummary, showcaseItems, preferredColor)
		{ }
	}
}
