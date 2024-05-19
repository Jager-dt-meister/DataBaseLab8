using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class ScheduleModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "ScheduleId")]
		public int ScheduleId { get; set; }

		[Display(Name = "SportId")]
		public int? SportId { get; set; }

		[Display(Name = "TrId")]
		public int? TrId { get; set; }

		[Display(Name = "GymId")]
		public int? GymId { get; set; }

		[Display(Name = "Date")]
		public string Date { get; set; }

		[Display(Name = "Duration")]
		public int? Duration { get; set; }

		public static ScheduleModel FromEntity(Schedule obj)
		{
			return obj == null ? null : new ScheduleModel
			{
				ScheduleId = obj.ScheduleId,
				SportId = obj.SportId,
				TrId = obj.TrId,
				GymId = obj.GymId,
				Date = obj.Date,
				Duration = obj.Duration,
			};
		}

		public static Schedule ToEntity(ScheduleModel obj)
		{
			return obj == null ? null : new Schedule(obj.ScheduleId, obj.SportId, obj.TrId, obj.GymId, obj.Date,
				obj.Duration);
		}

		public static List<ScheduleModel> FromEntitiesList(IEnumerable<Schedule> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Schedule> ToEntitiesList(IEnumerable<ScheduleModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
