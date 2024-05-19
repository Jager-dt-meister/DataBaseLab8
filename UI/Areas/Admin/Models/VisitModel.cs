using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class VisitModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "VisitId")]
		public int VisitId { get; set; }

		[Display(Name = "ScheduleId")]
		public int? ScheduleId { get; set; }

		[Display(Name = "PurchaseId")]
		public int? PurchaseId { get; set; }

		[Display(Name = "Realdate")]
		public DateTime? Realdate { get; set; }

		public static VisitModel FromEntity(Visit obj)
		{
			return obj == null ? null : new VisitModel
			{
				VisitId = obj.VisitId,
				ScheduleId = obj.ScheduleId,
				PurchaseId = obj.PurchaseId,
				Realdate = obj.Realdate,
			};
		}

		public static Visit ToEntity(VisitModel obj)
		{
			return obj == null ? null : new Visit(obj.VisitId, obj.ScheduleId, obj.PurchaseId, obj.Realdate);
		}

		public static List<VisitModel> FromEntitiesList(IEnumerable<Visit> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Visit> ToEntitiesList(IEnumerable<VisitModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
