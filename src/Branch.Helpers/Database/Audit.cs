using System;
using System.ComponentModel.DataAnnotations;

namespace Branch.Helpers.Database
{
	public abstract class Audit
	{
		/// <summary>
		/// Initalizes the abstract Audit base class.
		/// </summary>
		public Audit()
		{
			CreatedAt = UpdatedAt =
				DateTime.UtcNow;
		}

		/// <summary>
		/// The Id of the database item.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// The UTC formatted date the item was last written to.
		/// </summary>
		public DateTime UpdatedAt { get; set; }

		/// <summary>
		/// The UTC formatted date the item was created at.
		/// </summary>
		public DateTime CreatedAt { get; set; }
	}
}
