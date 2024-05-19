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
	public class SubsDal : BaseDal<DefaultDbContext, Sub, Entities.Sub, int, SubsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public SubsDal()
		{
		}

		protected internal SubsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Sub entity, Sub dbObject, bool exists)
		{
			dbObject.SubId = entity.SubId;
			dbObject.Name = entity.Name;
			dbObject.Price = entity.Price;
			dbObject.Duration = entity.Duration;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Sub>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Sub> dbObjects, SubsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Sub>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Sub> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Sub, int>> GetIdByDbObjectExpression()
		{
			return item => item.SubId;
		}

		protected override Expression<Func<Entities.Sub, int>> GetIdByEntityExpression()
		{
			return item => item.SubId;
		}

		internal static Entities.Sub ConvertDbObjectToEntity(Sub dbObject)
		{
			return dbObject == null ? null : new Entities.Sub(dbObject.SubId, dbObject.Name, dbObject.Price,
				dbObject.Duration);
		}
	}
}
