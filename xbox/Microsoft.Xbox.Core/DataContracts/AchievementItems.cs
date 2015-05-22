using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class AchievementItems<T>
		: Response
		where T : AchievementItem
	{
		[JsonProperty("achievements")]
		public IReadOnlyCollection<T> Achievements { get; set; }

		[JsonProperty("pagingInfo")]
		public PagingInfo PagingInfo { get; set; }
	}
}
