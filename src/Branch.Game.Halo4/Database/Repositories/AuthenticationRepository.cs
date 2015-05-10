using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Branch.Game.Halo4.Database.Models;
using System.Linq.Expressions;
using Branch.Game.Halo4.Database.Repositories.Interfaces;

namespace Branch.Game.Halo4.Database.Repositories
{
	public class AuthenticationRepository
		: IAuthenticationRepository
	{
		public AuthenticationRepository(Halo4DbContext halo4Context)
		{
			_halo4Context = halo4Context;
		}
		
		private Halo4DbContext _halo4Context { get; set; }

		public async Task<IEnumerable<Authentication>> GetAllAsync(int startAt = 0, int count = int.MaxValue)
		{
			return await _halo4Context.Authentications/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToListAsync();
		}

		public async Task<IEnumerable<Authentication>> Where(Expression<Func<Authentication,bool>> predicate)
		{
			return await _halo4Context.Authentications.Where(predicate).ToListAsync();
		}

		public async Task<Authentication> GetByIdAsync(int id)
		{
			return await _halo4Context.Authentications.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task<Authentication> AddAsync(Authentication item)
		{
			_halo4Context.Authentications.Add(item);
			if (await _halo4Context.SaveChangesAsync() <= 0)
				return null;

			return await GetByIdAsync(item.Id);
		}

		public async Task<Authentication> UpdateAsync(Authentication delta)
		{
			var item = await GetByIdAsync(delta.Id);
			if (item == null)
				return await AddAsync(delta);
			else
			{
				item.AnalyticsToken = delta.AnalyticsToken;
				item.ExpiresAt = delta.ExpiresAt;
				item.Gamertag = delta.Gamertag;
				item.SpartanToken = delta.SpartanToken;

				item.UpdatedAt = DateTime.UtcNow;
			}

			if (await _halo4Context.SaveChangesAsync() <= 0)
				return null;

			return await GetByIdAsync(item.Id);
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
