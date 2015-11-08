using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo4.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo4.Database.Repositories.Interfaces;

namespace Branch.Service.Halo4.Database.Repositories
{
	public class MatchRepository
		: IMatchRepository
	{
		public MatchRepository(Halo4DbContext halo4Context)
		{
			_halo4Context = halo4Context;
		}
		
		private Halo4DbContext _halo4Context { get; set; }

		public IEnumerable<Match> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return _halo4Context.Matches/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<Match> Where(Expression<Func<Match,bool>> predicate)
		{
			return _halo4Context.Matches.Where(predicate).AsEnumerable();
		}

		public Match GetById(int id)
		{
			return _halo4Context.Matches.FirstOrDefault(a => a.Id == id);
		}

		public Match Add(Match item)
		{
			_halo4Context.Matches.Add(item);
			if (_halo4Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public Match Update(Match delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);
			else
			{
				item.DocumentId = delta.DocumentId;
				item.GameMode = delta.GameMode;
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
