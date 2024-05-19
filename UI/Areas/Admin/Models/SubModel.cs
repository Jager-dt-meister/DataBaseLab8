using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class SubModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "SubId")]
		public int SubId { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Price")]
		public int? Price { get; set; }

		[Display(Name = "Duration")]
		public int? Duration { get; set; }

		public static SubModel FromEntity(Sub obj)
		{
			return obj == null ? null : new SubModel
			{
				SubId = obj.SubId,
				Name = obj.Name,
				Price = obj.Price,
				Duration = obj.Duration,
			};
		}

		public static Sub ToEntity(SubModel obj)
		{
			return obj == null ? null : new Sub(obj.SubId, obj.Name, obj.Price, obj.Duration);
		}

		public static List<SubModel> FromEntitiesList(IEnumerable<Sub> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Sub> ToEntitiesList(IEnumerable<SubModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
