using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class MedalStatistic
	{
		[JsonProperty("ClassId")]
		public MedalClass Class { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("ImageUrl")]
		public AssetContainer ImageUrl { get; set; }

		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("TotalMedals")]
		public int TotalMedals { get; set; }
	}
}
