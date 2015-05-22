using Microsoft.Xbox.Core.DataContracts;
using Microsoft.Xbox.Core.DataContracts.Abstracts;
using System.Collections.Generic;

namespace Branch.Service.XboxLive.Mvc.ViewModels
{
	public class AchievementsViewModel
		: ViewModelBase
	{
		public AchievementsViewModel(ProfileUser profileUser, ProfileSummary profileSummary,
			PreferredColor preferredColor, uint page, IEnumerable<UserTitle> userTitles,
			bool hasMoreUserTitles, IEnumerable<MediaItem> mediaItems)
			: base(profileUser, profileSummary, preferredColor)
		{
			Page = page;
			UserTitles = userTitles;
			HasMoreUserTitles = hasMoreUserTitles;
			MediaItems = mediaItems;
		}

		public uint Page { get; set; }

		public IEnumerable<UserTitle> UserTitles { get; set; }

		public bool HasMoreUserTitles { get; set; }

		public IEnumerable<MediaItem> MediaItems { get; set; }
	}
}
