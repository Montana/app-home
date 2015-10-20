using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo4.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo4.Database.Repositories.Interfaces;

namespace Branch.Service.Halo4.Database.Repositories
{
	public class MetadataRepository
		: IMetadataRepository
	{
		public MetadataRepository(Halo4DbContext halo4Context)
		{
			_halo4Context = halo4Context;
		}
		
		private Halo4DbContext _halo4Context { get; set; }

		public IEnumerable<Metadata> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return _halo4Context.Metadata/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<Metadata> Where(Expression<Func<Metadata,bool>> predicate)
		{
			return _halo4Context.Metadata.Where(predicate).AsEnumerable();
		}

		public Metadata GetById(int id)
		{
			return _halo4Context.Metadata.FirstOrDefault(a => a.Id == id);
		}

		public Metadata Add(Metadata item)
		{
			_halo4Context.Metadata.Add(item);
			if (_halo4Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public Metadata Update(Metadata delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);
			else
			{
				item.DocumentId = delta.DocumentId;

				item.UpdatedAt = DateTime.UtcNow;
			}

			if (_halo4Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public bool Delete(int id)
		{
			var item = GetById(id);
			if (item == null)
				return true;

			_halo4Context.Remove(item);
			return _halo4Context.SaveChanges() > 0;
		}
	}
}
