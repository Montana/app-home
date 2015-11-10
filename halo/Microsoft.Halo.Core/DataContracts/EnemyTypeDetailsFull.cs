using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class EnemyTypeDetailsFull
	{
		[JsonProperty("Id")]
		public EnemyType Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
