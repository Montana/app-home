using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts.Abstracts
{
	public class UserTitle
	{
		[JsonProperty("titleId")]
		public uint TitleId { get; set; }
		
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("currentGamerscore")]
		public uint CurrentGamerscore { get; set; }
	}
}
