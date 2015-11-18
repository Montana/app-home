using System;
using Branch.Helpers.Database;

namespace Branch.Service.Halo5.Database.Models
{
	public class GameVariant
		: Audit
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string IconUrl { get; set; }

		public Guid GameBaseVariantId { get; set; }

		public Guid GameVariantId { get; set; }

		public Nullable<Guid> ContentId { get; set; }
	}
}
