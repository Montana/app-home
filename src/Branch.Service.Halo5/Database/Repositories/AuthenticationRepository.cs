using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo5.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo5.Database.Repositories.Interfaces;

namespace Branch.Service.Halo5.Database.Repositories
{
	public class AuthenticationRepository
		: IAuthenticationRepository
	{
		public AuthenticationRepository(Halo5DbContext halo5Context)
		{
			Halo5Context = halo5Context;
		}

		private Halo5DbContext Halo5Context { get; }

		public IEnumerable<Authentication> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return Halo5Context.Authentications/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<Authentication> Where(Expression<Func<Authentication,bool>> predicate)
		{
			return Halo5Context.Authentications.Where(predicate).AsEnumerable();
		}

		public Authentication GetById(int id)
		{
			return Halo5Context.Authentications.FirstOrDefault(a => a.Id == id);
		}

		public Authentication Add(Authentication item)
		{
			Halo5Context.Authentications.Add(item);
			if (Halo5Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public Authentication Update(Authentication delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);

			item.AnalyticsToken = delta.AnalyticsToken;
			item.ExpiresAt = delta.ExpiresAt;
			item.Gamertag = delta.Gamertag;
			item.SpartanToken = delta.SpartanToken;

			item.UpdatedAt = DateTime.UtcNow;

			if (Halo5Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
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
