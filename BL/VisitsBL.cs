using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Visit = Entities.Visit;

namespace BL
{
	public class VisitsBL
	{
		public async Task<int> AddOrUpdateAsync(Visit entity)
		{
			entity.VisitId = await new VisitsDal().AddOrUpdateAsync(entity);
			return entity.VisitId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new VisitsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(VisitsSearchParams searchParams)
		{
			return new VisitsDal().ExistsAsync(searchParams);
		}

		public Task<Visit> GetAsync(int id)
		{
			return new VisitsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new VisitsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Visit>> GetAsync(VisitsSearchParams searchParams)
		{
			return new VisitsDal().GetAsync(searchParams);
		}
	}
}

