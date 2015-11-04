using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class SpecializationLevelDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("SpecializationId")]
		public int SpecializationId { get; set; }

		[JsonProperty("Level")]
		public int Level { get; set; }

		[JsonProperty("StartXp")]
		public int StartXp { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
