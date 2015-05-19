using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Branch.Service.Halo4.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo4.Database.Repositories.Interfaces;

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

		public async Task<IEnumerable<GameHistory>> GetAllAsync(int startAt = 0, int count = int.MaxValue)
		{
			return await _halo4Context.GameHistories/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToListAsync();
		}

		public IEnumerable<GameHistory> Where(Expression<Func<GameHistory,bool>> predicate)
		{
			return _halo4Context.GameHistories.Where(predicate).AsEnumerable();
		}

		public async Task<GameHistory> GetByIdAsync(int id)
		{
			return await _halo4Context.GameHistories.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task<GameHistory> AddAsync(GameHistory item)
		{
			_halo4Context.GameHistories.Add(item);
			if (await _halo4Context.SaveChangesAsync() <= 0)
				return null;

			return await GetByIdAsync(item.Id);
		}

		public async Task<GameHistory> UpdateAsync(GameHistory delta)
		{
			var item = await GetByIdAsync(delta.Id);
			if (item == null)
				return await AddAsync(delta);
			else
			{
				item.Count = delta.Count;
				item.DocumentId = delta.DocumentId;
				item.GameMode = delta.GameMode;
				item.ServiceRecordId = delta.ServiceRecordId;
				item.StartAt = delta.StartAt;

				item.UpdatedAt = DateTime.UtcNow;
			}

			if (await _halo4Context.SaveChangesAsync() <= 0)
				return null;

			return await GetByIdAsync(item.Id);
		}

		public async Task RefreshUpdatedAt(int id)
		{
			var item = await GetByIdAsync(id);
			if (item == null) return;

			await UpdateAsync(item);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var item = await GetByIdAsync(id);
			if (item == null)
				return true;

			_halo4Context.Remove(item);
			return await _halo4Context.SaveChangesAsync() > 0;
		}
	}
}
