using System.Collections.Generic;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class WeaponId
	{
		[JsonProperty("StockId")]
		public long StockId { get; set; }

		[JsonProperty("Attachments")]
		public IReadOnlyCollection<long> Attachments { get; set; }
	}
}
