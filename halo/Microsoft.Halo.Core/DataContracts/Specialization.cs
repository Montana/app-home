using System.Runtime.Serialization;

namespace Microsoft.Halo.Core.DataContracts
{
	[DataContract]
	public class Specialization
	{
		[DataMember(Name = "Id")]
		public uint Id { get; set; }

		[DataMember(Name = "Name")]
		public string Name { get; set; }

		[DataMember(Name = "ImageUrl")]
		public AssetContainer ImageUrl { get; set; }

		[DataMember(Name = "Level")]
		public uint Level { get; set; }

		[DataMember(Name = "LevelName")]
		public string LevelName { get; set; }

		[DataMember(Name = "PercentageComplete")]
		public uint PercentageComplete { get; set; }

		[DataMember(Name = "IsCurrent")]
		public bool IsCurrent { get; set; }

		[DataMember(Name = "Completed")]
		public bool Completed { get; set; }
	}
}
