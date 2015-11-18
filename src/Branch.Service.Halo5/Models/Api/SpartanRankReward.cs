using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Branch.Service.Halo5.Models.Api
{
	public class SpartanRankReward
	{
		[JsonProperty("xp")]
		public int Xp { get; set; }

		[JsonProperty("requisitionPacks")]
		public IReadOnlyCollection<RequisitionPack> RequisitionPacks { get; set; }

		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("contentId")]
		public Guid ContentId { get; set; }
	}
}
