using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CommendationDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("CategoryId")]
		public int CategoryId { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }
	}
}
