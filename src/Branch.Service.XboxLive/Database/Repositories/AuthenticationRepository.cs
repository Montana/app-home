using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Branch.Service.XboxLive.Database.Models;
using System.Linq.Expressions;
using Branch.Service.XboxLive.Database.Repositories.Interfaces;
using Branch.Service.XboxLive.Database;
using Microsoft.Data.Entity;

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

		public IEnumerable<Authentication> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return _xboxLiveContext.Authentications/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<Authentication> Where(Expression<Func<Authentication, bool>> predicate)
		{
			return _xboxLiveContext.Authentications.Where(predicate).AsEnumerable();
		}

		public Authentication GetById(int id)
		{
			return _xboxLiveContext.Authentications.FirstOrDefault(a => a.Id == id);
		}

		public Authentication Add(Authentication item)
		{
			_xboxLiveContext.Authentications.Add(item);
			if (_xboxLiveContext.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public Authentication Update(Authentication delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);
			else
			{
				item.ExpiresAt = delta.ExpiresAt;
				item.Gamertag = delta.Gamertag;
				item.Token = delta.Token;
				item.UserHash = delta.UserHash;
				item.Xuid = delta.Xuid;

				item.UpdatedAt = DateTime.UtcNow;
			}

			if (_xboxLiveContext.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public bool Delete(int id)
		{
			var item = GetById(id);
			if (item == null)
				return true;

			_xboxLiveContext.Remove(item);
			return _xboxLiveContext.SaveChanges() > 0;
		}
	}
}
