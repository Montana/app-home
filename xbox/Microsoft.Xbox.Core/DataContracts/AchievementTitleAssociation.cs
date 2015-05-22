using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class AchievementTitleAssociation
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }
	}
}
