using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class GymModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "GymId")]
		public int GymId { get; set; }

		[Display(Name = "SportId")]
		public int? SportId { get; set; }

		public static GymModel FromEntity(Gym obj)
		{
			return obj == null ? null : new GymModel
			{
				GymId = obj.GymId,
				SportId = obj.SportId,
			};
		}

		public static Gym ToEntity(GymModel obj)
		{
			return obj == null ? null : new Gym(obj.GymId, obj.SportId);
		}

		public static List<GymModel> FromEntitiesList(IEnumerable<Gym> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Gym> ToEntitiesList(IEnumerable<GymModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
