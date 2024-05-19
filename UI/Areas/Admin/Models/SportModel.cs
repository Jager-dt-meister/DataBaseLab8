using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class SportModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "SportId")]
		public int SportId { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		public static SportModel FromEntity(Sport obj)
		{
			return obj == null ? null : new SportModel
			{
				SportId = obj.SportId,
				Name = obj.Name,
			};
		}

		public static Sport ToEntity(SportModel obj)
		{
			return obj == null ? null : new Sport(obj.SportId, obj.Name);
		}

		public static List<SportModel> FromEntitiesList(IEnumerable<Sport> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Sport> ToEntitiesList(IEnumerable<SportModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
