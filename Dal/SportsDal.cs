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
	public class SportsDal : BaseDal<DefaultDbContext, Sport, Entities.Sport, int, SportsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public SportsDal()
		{
		}

		protected internal SportsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Sport entity, Sport dbObject, bool exists)
		{
			dbObject.SportId = entity.SportId;
			dbObject.Name = entity.Name;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Sport>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Sport> dbObjects, SportsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Sport>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Sport> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Sport, int>> GetIdByDbObjectExpression()
		{
			return item => item.SportId;
		}

		protected override Expression<Func<Entities.Sport, int>> GetIdByEntityExpression()
		{
			return item => item.SportId;
		}

		internal static Entities.Sport ConvertDbObjectToEntity(Sport dbObject)
		{
			return dbObject == null ? null : new Entities.Sport(dbObject.SportId, dbObject.Name);
		}
	}
}
