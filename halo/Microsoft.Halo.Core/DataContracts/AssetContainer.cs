using System.Runtime.Serialization;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class AssetContainer
	{
		[DataMember(Name = "BaseUrl")]
		public string BaseUrl { get; set; }

		[DataMember(Name = "AssetUrl")]
		public string AssetUrl { get; set; }
	}
}
