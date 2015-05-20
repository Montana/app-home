using Microsoft.Xbox.Core.DataContracts;

namespace Branch.Service.XboxLive.Mvc.ViewModels
{
	public abstract class ViewModelBase
	{
		public ViewModelBase(ProfileUser profileUser, ProfileSummary profileSummary,
			PreferredColor preferredColor)
		{
			ProfileUser = profileUser;
			ProfileSummary = profileSummary;
			PreferredColors = preferredColor;
		}

		public ProfileUser ProfileUser { get; set; }

		public ProfileSummary ProfileSummary { get; set; }

		public PreferredColor PreferredColors { get; set; }
	}
}
