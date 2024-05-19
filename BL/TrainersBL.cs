using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Trainer = Entities.Trainer;

namespace BL
{
	public class TrainersBL
	{
		public async Task<int> AddOrUpdateAsync(Trainer entity)
		{
			entity.TrId = await new TrainersDal().AddOrUpdateAsync(entity);
			return entity.TrId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new TrainersDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(TrainersSearchParams searchParams)
		{
			return new TrainersDal().ExistsAsync(searchParams);
		}

		public Task<Trainer> GetAsync(int id)
		{
			return new TrainersDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new TrainersDal().DeleteAsync(id);
		}

		public Task<SearchResult<Trainer>> GetAsync(TrainersSearchParams searchParams)
		{
			return new TrainersDal().GetAsync(searchParams);
		}
	}
}

