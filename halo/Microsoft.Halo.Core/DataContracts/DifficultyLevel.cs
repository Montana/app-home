using System.Runtime.Serialization;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class DifficultyLevel
	{
		[DataMember(Name = "Id")]
		public uint Id { get; set; }

		[DataMember(Name = "Name")]
		public string Name { get; set; }

		[DataMember(Name = "Description")]
		public string Description { get; set; }

		[DataMember(Name = "ImageId")]
		public AssetContainer ImageUrl { get; set; }
	}
}
