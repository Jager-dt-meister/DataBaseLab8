using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Sub = Entities.Sub;

namespace BL
{
	public class SubsBL
	{
		public async Task<int> AddOrUpdateAsync(Sub entity)
		{
			entity.SubId = await new SubsDal().AddOrUpdateAsync(entity);
			return entity.SubId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new SubsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(SubsSearchParams searchParams)
		{
			return new SubsDal().ExistsAsync(searchParams);
		}

		public Task<Sub> GetAsync(int id)
		{
			return new SubsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new SubsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Sub>> GetAsync(SubsSearchParams searchParams)
		{
			return new SubsDal().GetAsync(searchParams);
		}
	}
}

