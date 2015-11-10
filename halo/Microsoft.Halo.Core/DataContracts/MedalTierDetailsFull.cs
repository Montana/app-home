using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class MedalTierDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }
	}
}
