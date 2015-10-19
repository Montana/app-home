using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo4.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo4.Database.Repositories.Interfaces;

namespace Branch.Service.Halo4.Database.Repositories
{
	public class ServiceRecordRepository
		: IServiceRecordRepository
	{
		public ServiceRecordRepository(Halo4DbContext halo4Context)
		{
			_halo4Context = halo4Context;
		}
		
		private Halo4DbContext _halo4Context { get; set; }

		public  IEnumerable<ServiceRecord> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return _halo4Context.ServiceRecords/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<ServiceRecord> Where(Expression<Func<ServiceRecord,bool>> predicate)
		{
			return _halo4Context.ServiceRecords.Where(predicate).AsEnumerable();
		}

		public  ServiceRecord GetById(int id)
		{
			return _halo4Context.ServiceRecords.FirstOrDefault(a => a.Id == id);
		}

		public  ServiceRecord Add(ServiceRecord item)
		{
			_halo4Context.ServiceRecords.Add(item);
			if (_halo4Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public  ServiceRecord Update(ServiceRecord delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);
			else
			{
				item.Xuid = delta.Xuid;
				item.ServiceTag = delta.ServiceTag;
				item.DocumentId = delta.DocumentId;

				item.UpdatedAt = DateTime.UtcNow;
			}

			if (_halo4Context.SaveChanges() <= 0)
				return null;

			return GetById(item.Id);
		}

		public void RefreshUpdatedAt(int id)
		{
			var item = GetById(id);
			if (item == null) return;

			Update(item);
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
