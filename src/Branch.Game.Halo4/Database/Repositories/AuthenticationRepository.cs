using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Branch.Game.Halo4.Database;
using Branch.Helpers.Database.Repository;
using Branch.Service.Halo4.Database.Models;
using Microsoft.AspNet.Mvc;

namespace Branch.Service.Halo4.Database.Repositories
{
	public class AuthenticationRepository
		: IRepository<Authentication>
	{
		public AuthenticationRepository(Halo4Context halo4Context)
		{
			_halo4Context = halo4Context;
		}
		
		private Halo4Context _halo4Context { get; set; }

		public async Task<IEnumerable<Authentication>> GetAllAsync(int startAt = 0, int count = int.MaxValue)
		{
			return await _halo4Context.Authentications/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToListAsync();
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
