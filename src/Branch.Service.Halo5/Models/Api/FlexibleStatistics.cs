using System.Collections.Generic;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class FlexibleStatistics
	{
		public class FlexibleStats
		{
			[JsonProperty("MedalStatCounts")]
			public IReadOnlyCollection<MedalCountStatistic> MedalStatCounts { get; set; }

			[JsonProperty("ImpulseStatCounts")]
			public IReadOnlyCollection<ImpulseCountStatistic> ImpulseStatCounts { get; set; }

			[JsonProperty("MedalTimelapses")]
			public IReadOnlyCollection<MedalTimelapsStatistic> MedalTimelapses { get; set; }

			[JsonProperty("ImpulseTimelapses")]
			public IReadOnlyCollection<ImpulseTimelapsStatistic> ImpulseTimelapses { get; set; }
		}
	}
}
