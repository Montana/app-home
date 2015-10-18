using Branch.Helpers.Extentions;
using Branch.Helpers.Services;
using Branch.Service.XboxLive.Database;
using Branch.Service.XboxLive.DocumentDb;
using Branch.Service.Xuid.Exceptions;
using Branch.Service.Xuid.Services;
using Microsoft.Framework.Logging;
using Microsoft.Xbox.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Branch.Service.XboxLive.Services
{
	public class EntertainmentDiscoveryService
		: ServiceBase<EntertainmentDiscoveryService>
	{
		public EntertainmentDiscoveryService(ILoggerFactory loggerFactory, HttpManagerService httpManagerService, XuidLookupService xuidLookupService, XboxLiveDbContext halo4DbContext, XboxLiveDdbRepository halo4DdbRepository, AuthenticationService authenticationService)
			: base(loggerFactory, httpManagerService, xuidLookupService, halo4DbContext, halo4DdbRepository, authenticationService)
		{ }

		public const string GetMediaDetailsUrl = "https://eds.xboxlive.com/media/en-US/details?idType=XboxHexTitle&ids={0}&targetDevices=XboxOne&desiredMediaItemTypes=DApp.DGame.DGameDemo&desired=TitleId.RelatedMedia.ParentItems.ReleaseDate.Images.DeveloperName.PublisherName.ZuneId.ParentalRatings.AllTimeAverageRating.AllTimeRatingCount.ReducedDescription.Description.RatingId.UserRatingCount.RatingDescriptors.SlideShows.Genres.Capabilities.HasCompanion.IsBundle.BundlePrimaryItemId.IsPartOfAnyBundle.Availabilities";

		public async Task<IEnumerable<MediaItem>> GetMediaDetailsBatch(IEnumerable<UInt32> titleIds)
		{
			var mediaItemTasks = new List<Task<MediaItems>>();
			foreach (var chunk in titleIds.Chunk(10))
				mediaItemTasks.Add(GetMediaDetails(chunk));
			await Task.WhenAll(mediaItemTasks.ToArray());

			var mediaItems = new List<MediaItem>();
			foreach (var mediaItemTask in mediaItemTasks)
				mediaItems.AddRange(mediaItemTask.Result.Items ?? new List<MediaItem>());
			return mediaItems;
		}

		public async Task<MediaItems> GetMediaDetails(UInt32 titleId)
		{
			return await GetMediaDetails(new List<UInt32> { titleId });
		}

		public async Task<MediaItems> GetMediaDetails(IEnumerable<UInt32> titleIds)
		{
			if (titleIds.Count() > 10)
				throw new ArgumentOutOfRangeException("titleIds");

			var authentication = await AuthenticationService.GetAuthenticationAsync();
			var validAuthentication = authentication != null && authentication.Token != null;
			var durangoTitleHistoryUri = new Uri(string.Format(GetMediaDetailsUrl, String.Join(".", titleIds.Select(x => x.ToString("X")).ToArray())));

			if (!validAuthentication)
				throw new XboxLiveAuthenticationDownException();

			var mediaDetails = await HttpManagerService.ExecuteRequestAsync<MediaItems>(HttpMethod.GET, durangoTitleHistoryUri, headers:
				new Dictionary<string, string>
				{
					{ "x-xbl-client-context", "bing" },
					{ "x-xbl-client-type", "Companion" },
					{ "x-xbl-client-version", "2.0" },
					{ "x-xbl-contentrestrictions", "eyJ2ZXJzaW9uIjoyLCJkYXRhIjp7Imdlb2dyYXBoaWNSZWdpb24iOiJVUyIsIm1heEFnZVJhdGluZyI6MjU1LCJwcmVmZXJyZWRBZ2VSYXRpbmciOjI1NSwicmVzdHJpY3RQcm9tb3Rpb25hbENvbnRlbnQiOmZhbHNlfX0=" },
					{ "x-xbl-contract-version", "3.2" },
					{ "x-xbl-device-type", "WindowsPhone" },
					{ "Authorization", string.Format("XBL3.0 x={0};{1}", authentication.UserHash, authentication.Token) }
				});

			return mediaDetails;
		}
	}
}
