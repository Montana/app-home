using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo5.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo5.Database.Repositories.Interfaces;

namespace Branch.Service.Halo5.Database.Repositories
{
	public class MapVariantRepository
		: IMapVariantRepository
	{
		public MapVariantRepository(Halo5DbContext halo5Context)
		{
			Halo5Context = halo5Context;
		}

		private Halo5DbContext Halo5Context { get; }

		public IEnumerable<MapVariant> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return Halo5Context.MapVariants/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<MapVariant> Where(Expression<Func<MapVariant,bool>> predicate)
		{
			return Halo5Context.MapVariants.Where(predicate).AsEnumerable();
		}

		public MapVariant GetById(int id)
		{
			return Halo5Context.MapVariants.FirstOrDefault(a => a.Id == id);
		}

		public MapVariant Add(MapVariant item)
		{
			Halo5Context.MapVariants.Add(item);
			return Halo5Context.SaveChanges() <= 0
				? null
				: GetById(item.Id);
		}

		public MapVariant Update(MapVariant delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);

			item.Name = delta.Name;
			item.Description = delta.Description;
			item.MapImageUrl = delta.MapImageUrl;
			item.MapId = delta.MapId;
			item.MapVariantId = delta.MapVariantId;
			item.ContentId = delta.ContentId;

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
