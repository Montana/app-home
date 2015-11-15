using System.Collections.Generic;
using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class EnemyId
	{
		[JsonProperty("BaseId")]
		public long BaseId { get; set; }

		[JsonProperty("Attachments")]
		public IList<long> Attachments { get; set; }
	}
}
