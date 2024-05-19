using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Gym = Entities.Gym;

namespace BL
{
	public class GymsBL
	{
		public async Task<int> AddOrUpdateAsync(Gym entity)
		{
			entity.GymId = await new GymsDal().AddOrUpdateAsync(entity);
			return entity.GymId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new GymsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(GymsSearchParams searchParams)
		{
			return new GymsDal().ExistsAsync(searchParams);
		}

		public Task<Gym> GetAsync(int id)
		{
			return new GymsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new GymsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Gym>> GetAsync(GymsSearchParams searchParams)
		{
			return new GymsDal().GetAsync(searchParams);
		}
	}
}

