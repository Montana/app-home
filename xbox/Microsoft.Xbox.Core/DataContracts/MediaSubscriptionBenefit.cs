using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class MediaSubscriptionBenefit
	{
		[JsonProperty("ID")]
		public string ID { get; set; }

		[JsonProperty("Benefits")]
		public IList<string> Benefits { get; set; }
	}
}
