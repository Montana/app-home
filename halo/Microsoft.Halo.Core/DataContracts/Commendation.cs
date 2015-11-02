using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class Commendation
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("CategoryId")]
		public CommendationCategory Category { get; set; }

		[JsonProperty("CategoryName")]
		public string CategoryName { get; set; }

		[JsonProperty("Ticks")]
		public int Ticks { get; set; }

		[JsonProperty("LevelId")]
		public int LevelId { get; set; }

		[JsonProperty("LevelName")]
		public string LevelName { get; set; }

		[JsonProperty("LevelStartTicks")]
		public int LevelStartTicks { get; set; }

		[JsonProperty("NextLevel")]
		public CommendationNextLevel NextLevel { get; set; }
	}
}
