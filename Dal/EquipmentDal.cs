using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class EquipmentDal : BaseDal<DefaultDbContext, Equipment, Entities.Equipment, int, EquipmentSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public EquipmentDal()
		{
		}

		protected internal EquipmentDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Equipment entity, Equipment dbObject, bool exists)
		{
			dbObject.EqId = entity.EqId;
			dbObject.GymId = entity.GymId;
			dbObject.Name = entity.Name;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Equipment>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Equipment> dbObjects, EquipmentSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Equipment>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Equipment> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Equipment, int>> GetIdByDbObjectExpression()
		{
			return item => item.EqId;
		}

		protected override Expression<Func<Entities.Equipment, int>> GetIdByEntityExpression()
		{
			return item => item.EqId;
		}

		internal static Entities.Equipment ConvertDbObjectToEntity(Equipment dbObject)
		{
			return dbObject == null ? null : new Entities.Equipment(dbObject.EqId, dbObject.GymId, dbObject.Name);
		}
	}
}
