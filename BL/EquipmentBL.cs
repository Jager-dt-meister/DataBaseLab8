using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Equipment = Entities.Equipment;

namespace BL
{
	public class EquipmentBL
	{
		public async Task<int> AddOrUpdateAsync(Equipment entity)
		{
			entity.EqId = await new EquipmentDal().AddOrUpdateAsync(entity);
			return entity.EqId;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new EquipmentDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(EquipmentSearchParams searchParams)
		{
			return new EquipmentDal().ExistsAsync(searchParams);
		}

		public Task<Equipment> GetAsync(int id)
		{
			return new EquipmentDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new EquipmentDal().DeleteAsync(id);
		}

		public Task<SearchResult<Equipment>> GetAsync(EquipmentSearchParams searchParams)
		{
			return new EquipmentDal().GetAsync(searchParams);
		}
	}
}

