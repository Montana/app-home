using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class MediaAvailability
	{
		[JsonProperty("AvailabilityID")]
		public string AvailabilityId { get; set; }

		[JsonProperty("ContentId")]
		public string ContentId { get; set; }

		[JsonProperty("Devices")]
		public IList<MediaAvailabilityDevice> Devices { get; set; }

		[JsonProperty("LicensePolicyTicket")]
		public string LicensePolicyTicket { get; set; }

		[JsonProperty("OfferDisplayData")]
		public string OfferDisplayData { get; set; }

		[JsonProperty("SignedOffer")]
		public string SignedOffer { get; set; }

		[JsonProperty("SubscriptionBenefits")]
		public IList<MediaSubscriptionBenefit> SubscriptionBenefits { get; set; }
	}
}
