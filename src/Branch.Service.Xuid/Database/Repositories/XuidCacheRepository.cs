using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Xuid.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Xuid.Database.Repositories.Interfaces;

namespace Branch.Service.Xuid.Database.Repositories
{
	public class XuidCacheRepository
		: IXuidCacheRepository
	{
		public XuidCacheRepository(XuidDbContext xuidContext)
		{
			_xuidContext = xuidContext;
		}

		private readonly TimeSpan ExpireBuffer = new TimeSpan(0, 0, 8, 0);

		private XuidDbContext _xuidContext { get; set; }

		public IEnumerable<XuidCache> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return _xuidContext.XuidCaches/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<XuidCache> Where(Expression<Func<XuidCache, bool>> predicate)
		{
			return _xuidContext.XuidCaches.Where(predicate).AsEnumerable();
		}

		public XuidCache GetById(int id)
		{
			return _xuidContext.XuidCaches.FirstOrDefault(a => a.Id == id);
		}

		public XuidCache GetByXuid(long xuid)
		{
			return _xuidContext.XuidCaches.FirstOrDefault(x => x.Xuid == xuid);
		}

		public XuidCache GetByGamertag(string gamertag)
		{
			return _xuidContext.XuidCaches.FirstOrDefault(x => x.Gamertag == gamertag);
		}

		public XuidCache Add(XuidCache item)
		{
			var existingMaybe = GetByXuid(item.Xuid);
			if (existingMaybe != null)
			{
				item.Id = existingMaybe.Id;
				return Update(item);
			}
			else
				item.ExpiresAt = DateTime.UtcNow + ExpireBuffer;

			_xuidContext.XuidCaches.Add(item);
			if (_xuidContext.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public XuidCache Update(XuidCache delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);
			else
			{
				item.ExpiresAt = DateTime.UtcNow + ExpireBuffer;
				item.Gamertag = delta.Gamertag;
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
