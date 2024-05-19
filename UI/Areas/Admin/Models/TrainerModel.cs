using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class TrainerModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "TrId")]
		public int TrId { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Workhours")]
		public string Workhours { get; set; }

		public static TrainerModel FromEntity(Trainer obj)
		{
			return obj == null ? null : new TrainerModel
			{
				TrId = obj.TrId,
				Name = obj.Name,
				Workhours = obj.Workhours,
			};
		}

		public static Trainer ToEntity(TrainerModel obj)
		{
			return obj == null ? null : new Trainer(obj.TrId, obj.Name, obj.Workhours);
		}

		public static List<TrainerModel> FromEntitiesList(IEnumerable<Trainer> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Trainer> ToEntitiesList(IEnumerable<TrainerModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
