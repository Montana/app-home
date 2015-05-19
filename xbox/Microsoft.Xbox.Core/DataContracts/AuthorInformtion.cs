using Microsoft.Xbox.Core.DataContracts.Enum;
using Newtonsoft.Json;

namespace Microsoft.Xbox.Core.DataContracts
{
	public class AuthorInformtion
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("secondName")]
		public string SecondName { get; set; }

		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }

		[JsonProperty("authorType")]
		public AuthorType AuthorType { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
