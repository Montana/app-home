using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Branch.Service.Halo4.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo4.Database.Repositories.Interfaces;
using Microsoft.Data.Entity;

namespace Branch.Service.Halo4.Database.Repositories
{
	public class GameHistoryRepository
		: IGameHistoryRepository
	{
		public GameHistoryRepository(Halo4DbContext halo4Context)
		{
			_halo4Context = halo4Context;
		}
		
		private Halo4DbContext _halo4Context { get; set; }

		public IEnumerable<GameHistory> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return _halo4Context.GameHistories/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<GameHistory> Where(Expression<Func<GameHistory,bool>> predicate)
		{
			return _halo4Context.GameHistories.Where(predicate).AsEnumerable();
		}

		public GameHistory GetById(int id)
		{
			return _halo4Context.GameHistories.FirstOrDefault(a => a.Id == id);
		}

		public GameHistory Add(GameHistory item)
		{
			_halo4Context.GameHistories.Add(item);
			if (_halo4Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public GameHistory Update(GameHistory delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);
			else
			{
				item.Count = delta.Count;
				item.DocumentId = delta.DocumentId;
				item.GameMode = delta.GameMode;
				item.ServiceRecordId = delta.ServiceRecordId;
				item.StartAt = delta.StartAt;

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
