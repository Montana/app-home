using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Halo.Core.DataContracts
{
	public class EnemiesMetadata
	{
		[JsonProperty("EnemyClasses")]
		public IReadOnlyCollection<EnemyClassDetailsFull> EnemyClasses { get; set; }

		[JsonProperty("EnemyTypes")]
		public IReadOnlyCollection<EnemyTypeDetailsFull> EnemyTypes { get; set; }

		[JsonProperty("Enemies")]
		public IReadOnlyCollection<EnemyDetailsFull> Enemies { get; set; }
	}
}
