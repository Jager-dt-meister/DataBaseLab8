using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Sport = Entities.Sport;

namespace BL
{
	public class SportsBL
	{
		public async Task<int> AddOrUpdateAsync(Sport entity)
		{
			entity.SportId = await new SportsDal().AddOrUpdateAsync(entity);
			return entity.SportId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new SportsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(SportsSearchParams searchParams)
		{
			return new SportsDal().ExistsAsync(searchParams);
		}

		public Task<Sport> GetAsync(int id)
		{
			return new SportsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new SportsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Sport>> GetAsync(SportsSearchParams searchParams)
		{
			return new SportsDal().GetAsync(searchParams);
		}
	}
}

