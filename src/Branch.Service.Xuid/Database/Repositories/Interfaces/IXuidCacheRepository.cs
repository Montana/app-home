using Branch.Helpers.Database.Repository;
using Branch.Service.Xuid.Database.Models;
using System;

namespace Branch.Service.Xuid.Database.Repositories.Interfaces
{
	public interface IXuidCacheRepository
		: IRepository<XuidCache>
	{
		XuidCache GetByXuid(Int64 xuid);

		XuidCache GetByGamertag(string gamertag);
	}
}
