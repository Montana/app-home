using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo5.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo5.Database.Repositories.Interfaces;

namespace Branch.Service.Halo5.Database.Repositories
{
	public class ServiceRecordRepository
		: IServiceRecordRepository
	{
		public ServiceRecordRepository(Halo5DbContext halo5Context)
		{
			Halo5Context = halo5Context;
		}

		private Halo5DbContext Halo5Context { get; }

		public IEnumerable<ServiceRecord> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return Halo5Context.ServiceRecords/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<ServiceRecord> Where(Expression<Func<ServiceRecord,bool>> predicate)
		{
			return Halo5Context.ServiceRecords.Where(predicate).AsEnumerable();
		}

		public ServiceRecord GetById(int id)
		{
			return Halo5Context.ServiceRecords.FirstOrDefault(a => a.Id == id);
		}

		public ServiceRecord Add(ServiceRecord item)
		{
			Halo5Context.ServiceRecords.Add(item);
			return Halo5Context.SaveChanges() <= 0
				? null
				: GetById(item.Id);
		}

		public ServiceRecord Update(ServiceRecord delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);

			item.DocumentId = delta.DocumentId;
			item.Xuid = delta.Xuid;
			item.Type = delta.Type;

			item.UpdatedAt = DateTime.UtcNow;

			return Halo5Context.SaveChanges() <= 0
				? null
				: GetById(item.Id);
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
