namespace Microsoft.Halo.Core.DataContracts
{
	public class Medal
	{
		public uint Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public AssetContainer ImageUrl { get; set; }

		public uint TotalMedals { get; set; }
	}
}
