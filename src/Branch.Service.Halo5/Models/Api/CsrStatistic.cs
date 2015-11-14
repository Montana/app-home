using Newtonsoft.Json;

namespace Branch.Service.Halo5.Models.Api
{
	public class CsrStatistic
	{
		[JsonProperty("Tier")]
		public int Tier { get; set; }

		/// <summary>
		/// The Designation of the CSR. Options are:
		///   1 through 5: Normal designations
		///   6 and 7: Semi-pro and Pro respectively
		/// </summary>
		[JsonProperty("DesignationId")]
		public int DesignationId { get; set; }

		[JsonProperty("Csr")]
		public int Csr { get; set; }

		[JsonProperty("PercentToNextTier")]
		public int PercentToNextTier { get; set; }

		[JsonProperty("Rank")]
		public object Rank { get; set; }
	}
}
