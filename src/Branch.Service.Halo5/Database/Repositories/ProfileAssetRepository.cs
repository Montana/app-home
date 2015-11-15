﻿using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo5.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo5.Database.Repositories.Interfaces;

namespace Branch.Service.Halo5.Database.Repositories
{
	public class ProfileAssetRepository
		: IProfileAssetRepository
	{
		public ProfileAssetRepository(Halo5DbContext halo5Context)
		{
			Halo5Context = halo5Context;
		}

		private Halo5DbContext Halo5Context { get; }

		public IEnumerable<ProfileAsset> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return Halo5Context.ProfileAssets/*.Skip(startAt).Take(count).OrderBy(a => a.Id)*/.ToList();
		}

		public IEnumerable<ProfileAsset> Where(Expression<Func<ProfileAsset,bool>> predicate)
		{
			return Halo5Context.ProfileAssets.Where(predicate).AsEnumerable();
		}

		public ProfileAsset GetById(int id)
		{
			return Halo5Context.ProfileAssets.FirstOrDefault(a => a.Id == id);
		}

		public ProfileAsset Add(ProfileAsset item)
		{
			Halo5Context.ProfileAssets.Add(item);
			return Halo5Context.SaveChanges() <= 0
				? null
				: GetById(item.Id);
		}

		public ProfileAsset Update(ProfileAsset delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);

			item.ImagePath = delta.ImagePath;
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
