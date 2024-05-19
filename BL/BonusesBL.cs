using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Bonuse = Entities.Bonuse;

namespace BL
{
	public class BonusesBL
	{
		public async Task<int> AddOrUpdateAsync(Bonuse entity)
		{
			entity.BonusId = await new BonusesDal().AddOrUpdateAsync(entity);
			return entity.BonusId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new BonusesDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(BonusesSearchParams searchParams)
		{
			return new BonusesDal().ExistsAsync(searchParams);
		}

		public Task<Bonuse> GetAsync(int id)
		{
			return new BonusesDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new BonusesDal().DeleteAsync(id);
		}

		public Task<SearchResult<Bonuse>> GetAsync(BonusesSearchParams searchParams)
		{
			return new BonusesDal().GetAsync(searchParams);
		}
	}
}

