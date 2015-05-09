namespace Microsoft.Halo.Core.DataContracts
{
	public class Specialization
	{
		public uint Id { get; set; }

		public string Name { get; set; }

		public AssetContainer ImageUrl { get; set; }

		public uint Level { get; set; }

		public string LevelName { get; set; }

		public uint PercentageComplete { get; set; }

		public bool IsCurrent { get; set; }

		public bool Completed { get; set; }
	}
}
