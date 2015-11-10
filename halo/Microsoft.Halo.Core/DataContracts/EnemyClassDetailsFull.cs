using Microsoft.Halo.Core.DataContracts.Enums;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class EnemyClassDetailsFull
	{
		[JsonProperty("Id")]
		public EnemyClass Id { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
