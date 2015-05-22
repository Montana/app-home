using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Microsoft.Xbox.Core.DataContracts
{
	public class RelatedMedia
	{
		[JsonProperty("ID")]
		public Guid Id { get; set; }

		[JsonProperty("IsDefaultCompanion")]
		public bool IsDefaultCompanion { get; set; }

		[JsonProperty("RelationType")]
		public string RelationType { get; set; }
	}
}
