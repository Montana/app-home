using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class AchievementProgressionRequirement
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("current")]
		public string Current { get; set; }

		[JsonProperty("target")]
		public string Target { get; set; }

		[JsonProperty("operationType")]
		public string OperationType { get; set; }

		[JsonProperty("valueType")]
		public string ValueType { get; set; }

		[JsonProperty("ruleParticipationType")]
		public string RuleParticipationType { get; set; }
	}
}
