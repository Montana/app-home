using System;
using System.Collections.Generic;
using System.Linq;
using Branch.Service.Halo5.Database.Models;
using System.Linq.Expressions;
using Branch.Service.Halo5.Database.Repositories.Interfaces;

namespace Branch.Service.Halo5.Database.Repositories
{
	public class PlayerRepository
		: IPlayerRepository
	{
		public PlayerRepository(Halo5DbContext halo5Context)
		{
			Halo5Context = halo5Context;
		}

		private Halo5DbContext Halo5Context { get; }

		public IEnumerable<Player> GetAll(int startAt = 0, int count = int.MaxValue)
		{
			return Halo5Context.Players.ToList();
		}

		public IEnumerable<Player> Where(Expression<Func<Player,bool>> predicate)
		{
			return Halo5Context.Players.Where(predicate).AsEnumerable();
		}

		public Player GetById(int id)
		{
			return Halo5Context.Players.FirstOrDefault(a => a.Id == id);
		}

		public Player Add(Player item)
		{
			Halo5Context.Players.Add(item);
			return Halo5Context.SaveChanges() <= 0
				? null
				: GetById(item.Id);
		}

		public Player Update(Player delta)
		{
			var item = GetById(delta.Id);
			if (item == null)
				return Add(delta);
			
			item.Xuid = delta.Xuid;
			item.ServiceTag = delta.ServiceTag;
			item.SpartanRank = delta.SpartanRank;
			item.Xp = delta.Xp;

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
