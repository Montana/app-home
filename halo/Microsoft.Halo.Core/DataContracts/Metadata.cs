﻿using Microsoft.Halo.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Halo.Core.DataContracts
{
	public class Metadata
		: Response
	{
		[JsonProperty("CommendationsMetadata")]
		public CommendationsMetadata CommendationsMetadata { get; set; }

		[JsonProperty("DifficultiesMetadata")]
		public DifficultiesMetadata DifficultiesMetadata { get; set; }

		[JsonProperty("EnemiesMetadata")]
		public EnemiesMetadata EnemiesMetadata { get; set; }

		[JsonProperty("FactionsMetadata")]
		public FactionsMetadata FactionsMetadata { get; set; }

		[JsonProperty("GameBaseVariantsMetadata")]
		public GameBaseVariantsMetadata GameBaseVariantsMetadata { get; set; }

		[JsonProperty("MapsMetadata")]
		public MapsMetadata MapsMetadata { get; set; }

		[JsonProperty("MedalsMetadata")]
		public MedalsMetadata MedalsMetadata { get; set; }

		[JsonProperty("PlaylistsMetadata")]
		public PlaylistsMetadata PlaylistsMetadata { get; set; }

		[JsonProperty("SpartanOpsMetadata")]
		public SpartanOpsMetadata SpartanOpsMetadata { get; set; }

		[JsonProperty("SpecializationsMetadata")]
		public SpecializationsMetadata SpecializationsMetadata { get; set; }
	}
}
