using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo4.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo4.Database.Repositories.Interfaces;

namespace Branch.Service.Halo4.Database.Repositories
{
	public class CommendationsRepository
		: ICommendationsRepository
	{
		public CommendationsRepository(Halo4DbContext halo4Context)
		{
			_halo4Context = halo4Context;
		}
		
		private Halo4DbContext _halo4Context { get; set; }

		public IEnumerable<Commendations> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return _halo4Context.Commendations/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<Commendations> Where(Expression<Func<Commendations,bool>> predicate)
		{
			return _halo4Context.Commendations.Where(predicate).AsEnumerable();
		}

		public Commendations GetById(int id)
		{
			return _halo4Context.Commendations.FirstOrDefault(a => a.Id == id);
		}

		public Commendations Add(Commendations item)
		{
			_halo4Context.Commendations.Add(item);
			if (_halo4Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public Commendations Update(Commendations delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);
			else
			{
				item.DocumentId = delta.DocumentId;
				item.ServiceRecordId = delta.ServiceRecordId;

				item.UpdatedAt = DateTime.UtcNow;
			}

			if (_halo4Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public void RefreshUpdatedAt(int id)
		{
			var item = GetById(id);
			if (item == null) return;

			Update(item);
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
