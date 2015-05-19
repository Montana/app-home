using System.Collections.Generic;
using Microsoft.Xbox.Core.DataContracts.Abstracts;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class ProfileUsers
		: Response
	{
		[JsonProperty("profileUsers")]
		public IReadOnlyCollection<ProfileUser> Users { get; set; }
	}
}
