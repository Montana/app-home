using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class CommendationCategoryMetadata
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
