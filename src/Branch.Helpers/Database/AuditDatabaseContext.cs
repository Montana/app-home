using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.ChangeTracking;

namespace Branch.Helpers.Database
{
	public class AuditDatabaseContext
		: DbContext
	{
		#region [ Overrides & Audit ]

		/// <summary>
		/// Save pending changes to the database.
		/// </summary>
		/// <returns>Returns the number of changes saved.</returns>
		public override int SaveChanges()
		{
			UpdateAuditInformation();
			return base.SaveChanges();
		}

		/// <summary>
		/// Gets the tracker entries.
		/// </summary>
		private IEnumerable<EntityEntry> ChangeTrackerEntries
		{
			get { return ChangeTracker.Entries().AsEnumerable(); }
		}

		/// <summary>
		/// Updates the added and modified audit information.
		/// </summary>
		private void UpdateAuditInformation()
		{
			UpdateAddedEntries();
			UpdateModifiedEntries();
		}

		/// <summary>
		/// Updates the added entries, sets their Created At, and Updated At times.
		/// </summary>
		private void UpdateAddedEntries()
		{
			var addedEntries = ChangeTrackerEntries.Where(e => e.State == EntityState.Added && e.Entity is Audit).Select(e => e.Entity as Audit);
			foreach (var addedEntry in addedEntries)
				addedEntry.UpdatedAt = addedEntry.CreatedAt = DateTime.UtcNow;
		}

		/// <summary>
		/// Updates the modified entries, sets their Updated At times.
		/// </summary>
		private void UpdateModifiedEntries()
		{
			var modifiedEntries = ChangeTrackerEntries.Where(e => e.State == EntityState.Modified && e.Entity is Audit).Select(e => e.Entity as Audit);
			foreach (var modifiedEntry in modifiedEntries)
				modifiedEntry.UpdatedAt = DateTime.UtcNow;
		}

		#endregion
	}
}
