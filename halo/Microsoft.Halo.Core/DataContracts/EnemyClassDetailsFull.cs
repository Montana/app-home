using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class EnemyClassDetailsFull
	{
		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
