using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Branch.Service.XboxLive.Database.Models;
using System.Linq.Expressions;
using Branch.Service.XboxLive.Database.Repositories.Interfaces;
using Branch.Service.XboxLive.Database;

namespace Branch.Service.Halo4.Database.Repositories
{
	public class AuthenticationRepository
		: IAuthenticationRepository
	{
		public AuthenticationRepository(XboxLiveDbContext xboxLiveContext)
		{
			_xboxLiveContext = xboxLiveContext;
		}

		private XboxLiveDbContext _xboxLiveContext { get; set; }

		public async Task<IEnumerable<Authentication>> GetAllAsync(int startAt = 0, int count = int.MaxValue)
		{
			return await _xboxLiveContext.Authentications/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToListAsync();
		}

		public IEnumerable<Authentication> Where(Expression<Func<Authentication, bool>> predicate)
		{
			return _xboxLiveContext.Authentications.Where(predicate).AsEnumerable();
		}

		public async Task<Authentication> GetByIdAsync(int id)
		{
			return await _xboxLiveContext.Authentications.FirstOrDefaultAsync(a => a.Id == id);
		}

		public async Task<Authentication> AddAsync(Authentication item)
		{
			_xboxLiveContext.Authentications.Add(item);
			if (await _xboxLiveContext.SaveChangesAsync() <= 0)
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
				item.ExpiresAt = delta.ExpiresAt;
				item.Gamertag = delta.Gamertag;
				item.Token = delta.Token;
				item.UserHash = delta.Gamertag;
				item.Xuid = delta.Xuid;

				item.UpdatedAt = DateTime.UtcNow;
			}

			if (await _xboxLiveContext.SaveChangesAsync() <= 0)
				return null;

			return await GetByIdAsync(item.Id);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var item = await GetByIdAsync(id);
			if (item == null)
				return true;

			_xboxLiveContext.Remove(item);
			return await _xboxLiveContext.SaveChangesAsync() > 0;
		}
	}
}
