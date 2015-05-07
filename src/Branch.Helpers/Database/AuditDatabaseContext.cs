﻿using System;
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

		public override int SaveChanges()
		{
			UpdateAuditInformation();
			return base.SaveChanges();
		}

		private IEnumerable<EntityEntry> ChangeTrackerEntries
		{
			get { return ChangeTracker.Entries().AsEnumerable(); }
		}

		private void UpdateAuditInformation()
		{
			UpdateAddedEntries();
			UpdateModifiedEntries();
		}

		private void UpdateAddedEntries()
		{
			var addedEntries = ChangeTrackerEntries.Where(e => e.State == EntityState.Added && e.Entity is Audit).Select(e => e.Entity as Audit);
			foreach (var addedEntry in addedEntries)
				addedEntry.UpdatedAt = addedEntry.CreatedAt = DateTime.UtcNow;
		}

		private void UpdateModifiedEntries()
		{
			var modifiedEntries = ChangeTrackerEntries.Where(e => e.State == EntityState.Modified && e.Entity is Audit).Select(e => e.Entity as Audit);
			foreach (var modifiedEntry in modifiedEntries)
				modifiedEntry.UpdatedAt = DateTime.UtcNow;
		}

		#endregion
	}
}
