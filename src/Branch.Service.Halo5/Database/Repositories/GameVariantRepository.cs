using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo5.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo5.Database.Repositories.Interfaces;

namespace Branch.Service.Halo5.Database.Repositories
{
	public class GameVariantRepository
		: IGameVariantRepository
	{
		public GameVariantRepository(Halo5DbContext halo5Context)
		{
			Halo5Context = halo5Context;
		}

		private Halo5DbContext Halo5Context { get; }

		public IEnumerable<GameVariant> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return Halo5Context.GameVariants/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<GameVariant> Where(Expression<Func<GameVariant,bool>> predicate)
		{
			return Halo5Context.GameVariants.Where(predicate).AsEnumerable();
		}

		public GameVariant GetById(int id)
		{
			return Halo5Context.GameVariants.FirstOrDefault(a => a.Id == id);
		}

		public GameVariant Add(GameVariant item)
		{
			Halo5Context.GameVariants.Add(item);
			return Halo5Context.SaveChanges() <= 0
				? null
				: GetById(item.Id);
		}

		public GameVariant Update(GameVariant delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);

			item.Name = delta.Name;
			item.Description = delta.Description;
			item.IconUrl = delta.IconUrl;
			item.GameBaseVariantId = delta.GameBaseVariantId;
			item.GameVariantId = delta.GameVariantId;
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
