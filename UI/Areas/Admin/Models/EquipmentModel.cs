using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class EquipmentModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "EqId")]
		public int EqId { get; set; }

		[Display(Name = "GymId")]
		public int? GymId { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		public static EquipmentModel FromEntity(Equipment obj)
		{
			return obj == null ? null : new EquipmentModel
			{
				EqId = obj.EqId,
				GymId = obj.GymId,
				Name = obj.Name,
			};
		}

		public static Equipment ToEntity(EquipmentModel obj)
		{
			return obj == null ? null : new Equipment(obj.EqId, obj.GymId, obj.Name);
		}

		public static List<EquipmentModel> FromEntitiesList(IEnumerable<Equipment> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Equipment> ToEntitiesList(IEnumerable<EquipmentModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
