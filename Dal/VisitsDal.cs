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
	public class VisitsDal : BaseDal<DefaultDbContext, Visit, Entities.Visit, int, VisitsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public VisitsDal()
		{
		}

		protected internal VisitsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Visit entity, Visit dbObject, bool exists)
		{
			dbObject.VisitId = entity.VisitId;
			dbObject.ScheduleId = entity.ScheduleId;
			dbObject.PurchaseId = entity.PurchaseId;
			dbObject.Realdate = entity.Realdate;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Visit>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Visit> dbObjects, VisitsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Visit>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Visit> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Visit, int>> GetIdByDbObjectExpression()
		{
			return item => item.VisitId;
		}

		protected override Expression<Func<Entities.Visit, int>> GetIdByEntityExpression()
		{
			return item => item.VisitId;
		}

		internal static Entities.Visit ConvertDbObjectToEntity(Visit dbObject)
		{
			return dbObject == null ? null : new Entities.Visit(dbObject.VisitId, dbObject.ScheduleId,
				dbObject.PurchaseId, dbObject.Realdate);
		}
	}
}
