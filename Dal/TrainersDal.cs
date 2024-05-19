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
	public class TrainersDal : BaseDal<DefaultDbContext, Trainer, Entities.Trainer, int, TrainersSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public TrainersDal()
		{
		}

		protected internal TrainersDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Trainer entity, Trainer dbObject, bool exists)
		{
			dbObject.TrId = entity.TrId;
			dbObject.Name = entity.Name;
			dbObject.Workhours = entity.Workhours;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Trainer>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Trainer> dbObjects, TrainersSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Trainer>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Trainer> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Trainer, int>> GetIdByDbObjectExpression()
		{
			return item => item.TrId;
		}

		protected override Expression<Func<Entities.Trainer, int>> GetIdByEntityExpression()
		{
			return item => item.TrId;
		}

		internal static Entities.Trainer ConvertDbObjectToEntity(Trainer dbObject)
		{
			return dbObject == null ? null : new Entities.Trainer(dbObject.TrId, dbObject.Name, dbObject.Workhours);
		}
	}
}
