using System.Runtime.Serialization;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class Medal
	{
		[DataMember(Name = "Id")]
		public uint Id { get; set; }

		[DataMember(Name = "Name")]
		public string Name { get; set; }

		[DataMember(Name = "Description")]
		public string Description { get; set; }

		[DataMember(Name = "ImageUrl")]
		public AssetContainer ImageUrl { get; set; }

		[DataMember(Name = "TotalMedals")]
		public uint TotalMedals { get; set; }
	}
}
