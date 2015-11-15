using System;
using Branch.Helpers.Database;
using Branch.Service.Halo5.Database.Enums;

namespace Branch.Service.Halo5.Database.Models
{
	public class ProfileAsset
		: Audit
	{
		public Int64 Xuid { get; set; }

		public string ImagePath { get; set; }

		public ProfileAssetType Type { get; set; }
	}
}
