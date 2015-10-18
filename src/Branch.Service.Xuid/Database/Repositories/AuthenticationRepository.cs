using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Xuid.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Xuid.Database.Repositories.Interfaces;

namespace Branch.Service.Xuid.Database.Repositories
{
	public class AuthenticationRepository
		: IAuthenticationRepository
	{
		public AuthenticationRepository(XuidDbContext xuidContext)
		{
			_xuidContext = xuidContext;
		}

		private XuidDbContext _xuidContext { get; set; }

		public IEnumerable<Authentication> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return _xuidContext.Authentications/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<Authentication> Where(Expression<Func<Authentication, bool>> predicate)
		{
			return _xuidContext.Authentications.Where(predicate).AsEnumerable();
		}

		public Authentication GetById(int id)
		{
			return _xuidContext.Authentications.FirstOrDefault(a => a.Id == id);
		}

		public Authentication Add(Authentication item)
		{
			_xuidContext.Authentications.Add(item);
			if (_xuidContext.SaveChanges() <= 0)
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

			if (_xuidContext.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public bool Delete(int id)
		{
			var item = GetById(id);
			if (item == null)
				return true;

			_xuidContext.Remove(item);
			return _xuidContext.SaveChanges() > 0;
		}
	}
}
