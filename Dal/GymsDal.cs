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
	public class GymsDal : BaseDal<DefaultDbContext, Gym, Entities.Gym, int, GymsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public GymsDal()
		{
		}

		protected internal GymsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Gym entity, Gym dbObject, bool exists)
		{
			dbObject.GymId = entity.GymId;
			dbObject.SportId = entity.SportId;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Gym>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Gym> dbObjects, GymsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Gym>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Gym> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Gym, int>> GetIdByDbObjectExpression()
		{
			return item => item.GymId;
		}

		protected override Expression<Func<Entities.Gym, int>> GetIdByEntityExpression()
		{
			return item => item.GymId;
		}

		internal static Entities.Gym ConvertDbObjectToEntity(Gym dbObject)
		{
			return dbObject == null ? null : new Entities.Gym(dbObject.GymId, dbObject.SportId);
		}
	}
}
