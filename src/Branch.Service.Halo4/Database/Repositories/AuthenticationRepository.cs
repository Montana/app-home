using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Branch.Service.Halo4.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo4.Database.Repositories.Interfaces;

namespace Branch.Service.Halo4.Database.Repositories
{
	public class AuthenticationRepository
		: IAuthenticationRepository
	{
		public AuthenticationRepository(Halo4DbContext halo4Context)
		{
			_halo4Context = halo4Context;
		}
		
		private Halo4DbContext _halo4Context { get; set; }

		public IEnumerable<Authentication> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return _halo4Context.Authentications/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<Authentication> Where(Expression<Func<Authentication,bool>> predicate)
		{
			return _halo4Context.Authentications.Where(predicate).AsEnumerable();
		}

		public Authentication GetById(int id)
		{
			return _halo4Context.Authentications.FirstOrDefault(a => a.Id == id);
		}

		public Authentication Add(Authentication item)
		{
			_halo4Context.Authentications.Add(item);
			if (_halo4Context.SaveChanges() <= 0)
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
				item.AnalyticsToken = delta.AnalyticsToken;
				item.ExpiresAt = delta.ExpiresAt;
				item.Gamertag = delta.Gamertag;
				item.SpartanToken = delta.SpartanToken;

				item.UpdatedAt = DateTime.UtcNow;
			}

			if (_halo4Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
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
