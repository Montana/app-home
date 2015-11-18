using System;
using Branch.Helpers.Database;

namespace Branch.Service.Halo5.Database.Models
{
	public class MapVariant
		: Audit
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string MapImageUrl { get; set; }

		public Guid MapId { get; set; }

		public Guid MapVariantId { get; set; }

		public Nullable<Guid> ContentId { get; set; }
	}
}
