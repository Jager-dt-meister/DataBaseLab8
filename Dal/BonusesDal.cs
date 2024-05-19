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
	public class BonusesDal : BaseDal<DefaultDbContext, Bonuse, Entities.Bonuse, int, BonusesSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public BonusesDal()
		{
		}

		protected internal BonusesDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Bonuse entity, Bonuse dbObject, bool exists)
		{
			dbObject.BonusId = entity.BonusId;
			dbObject.Name = entity.Name;
			dbObject.Number = entity.Number;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Bonuse>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Bonuse> dbObjects, BonusesSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Bonuse>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Bonuse> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Bonuse, int>> GetIdByDbObjectExpression()
		{
			return item => item.BonusId;
		}

		protected override Expression<Func<Entities.Bonuse, int>> GetIdByEntityExpression()
		{
			return item => item.BonusId;
		}

		internal static Entities.Bonuse ConvertDbObjectToEntity(Bonuse dbObject)
		{
			return dbObject == null ? null : new Entities.Bonuse(dbObject.BonusId, dbObject.Name, dbObject.Number);
		}
	}
}
