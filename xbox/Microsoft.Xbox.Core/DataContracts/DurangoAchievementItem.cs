using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class DurangoAchievementItem
		: AchievementItem
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("serviceConfigId")]
		public string ServiceConfigId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("titleAssociations")]
		public IReadOnlyCollection<AchievementTitleAssociation> TitleAssociations { get; set; }

		[JsonProperty("progressState")]
		public string ProgressState { get; set; }

		[JsonProperty("progression")]
		public AchievementProgression Progression { get; set; }

		[JsonProperty("mediaAssets")]
		public IReadOnlyCollection<AchievementMediaAsset> MediaAssets { get; set; }

		[JsonProperty("platforms")]
		public IReadOnlyCollection<string> Platforms { get; set; }

		[JsonProperty("isSecret")]
		public bool IsSecret { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("lockedDescription")]
		public string LockedDescription { get; set; }

		[JsonProperty("productId")]
		public string ProductId { get; set; }

		[JsonProperty("achievementType")]
		public string AchievementType { get; set; }

		[JsonProperty("participationType")]
		public string ParticipationType { get; set; }
		
		[JsonProperty("rewards")]
		public IReadOnlyCollection<AchievementAward> Rewards { get; set; }

		[JsonProperty("estimatedTime")]
		public string EstimatedTime { get; set; }

		[JsonProperty("deeplink")]
		public object Deeplink { get; set; }

		[JsonProperty("isRevoked")]
		public bool IsRevoked { get; set; }
	}
}
