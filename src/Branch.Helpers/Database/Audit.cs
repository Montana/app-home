using System;
using System.ComponentModel.DataAnnotations;

namespace Branch.Helpers.Database
{
	public class Audit
	{
		public Audit()
		{
			CreatedAt = UpdatedAt =
				DateTime.UtcNow;
		}

		[Key]
		public int Id { get; set; }

		public DateTime UpdatedAt { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}
