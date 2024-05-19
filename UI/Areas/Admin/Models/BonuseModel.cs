using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class BonuseModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "BonusId")]
		public int BonusId { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Number")]
		public int? Number { get; set; }

		public static BonuseModel FromEntity(Bonuse obj)
		{
			return obj == null ? null : new BonuseModel
			{
				BonusId = obj.BonusId,
				Name = obj.Name,
				Number = obj.Number,
			};
		}

		public static Bonuse ToEntity(BonuseModel obj)
		{
			return obj == null ? null : new Bonuse(obj.BonusId, obj.Name, obj.Number);
		}

		public static List<BonuseModel> FromEntitiesList(IEnumerable<Bonuse> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Bonuse> ToEntitiesList(IEnumerable<BonuseModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
