using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo5.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo5.Database.Repositories.Interfaces;

namespace Branch.Service.Halo5.Database.Repositories
{
	public class MatchHistoryRepository
		: IMatchHistoryRepository
	{
		public MatchHistoryRepository(Halo5DbContext halo5Context)
		{
			Halo5Context = halo5Context;
		}

		private Halo5DbContext Halo5Context { get; }

		public IEnumerable<MatchHistory> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return Halo5Context.MatchHistories/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<MatchHistory> Where(Expression<Func<MatchHistory,bool>> predicate)
		{
			return Halo5Context.MatchHistories.Where(predicate).AsEnumerable();
		}

		public MatchHistory GetById(int id)
		{
			return Halo5Context.MatchHistories.FirstOrDefault(a => a.Id == id);
		}

		public MatchHistory Add(MatchHistory item)
		{
			Halo5Context.MatchHistories.Add(item);
			return Halo5Context.SaveChanges() <= 0
				? null
				: GetById(item.Id);
		}

		public MatchHistory Update(MatchHistory delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);
			
			item.Xuid = delta.Xuid;
			item.Mode = delta.Mode;
			item.Start = delta.Start;
			item.Count = delta.Count;

			item.UpdatedAt = DateTime.UtcNow;

			return Halo5Context.SaveChanges() <= 0
				? null
				: GetById(item.Id);
		}

		public bool Delete(int id)
		{
			var item = GetById(id);
			if (item == null)
				return true;

			Halo5Context.Remove(item);
			return Halo5Context.SaveChanges() > 0;
		}
	}
}
