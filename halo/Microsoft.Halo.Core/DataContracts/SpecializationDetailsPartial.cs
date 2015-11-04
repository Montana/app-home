using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{

	public class SpecializationDetailsPartial
	{
		[JsonProperty("Id")]
		public uint Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }

		[JsonProperty("Level")]
		public uint Level { get; set; }

		[JsonProperty("LevelName")]
		public string LevelName { get; set; }

		[JsonProperty("PercentageComplete")]
		public uint PercentageComplete { get; set; }

		[JsonProperty("IsCurrent")]
		public bool IsCurrent { get; set; }

		[JsonProperty("Completed")]
		public bool Completed { get; set; }
	}
}
