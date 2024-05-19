using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class PurchaseModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "PurchaseId")]
		public int PurchaseId { get; set; }

		[Display(Name = "BonusId")]
		public int? BonusId { get; set; }

		[Display(Name = "ClientId")]
		public int? ClientId { get; set; }

		[Display(Name = "SubId")]
		public int? SubId { get; set; }

		[Display(Name = "Date")]
		public DateTime? Date { get; set; }

		public static PurchaseModel FromEntity(Purchase obj)
		{
			return obj == null ? null : new PurchaseModel
			{
				PurchaseId = obj.PurchaseId,
				BonusId = obj.BonusId,
				ClientId = obj.ClientId,
				SubId = obj.SubId,
				Date = obj.Date,
			};
		}

		public static Purchase ToEntity(PurchaseModel obj)
		{
			return obj == null ? null : new Purchase(obj.PurchaseId, obj.BonusId, obj.ClientId, obj.SubId, obj.Date);
		}

		public static List<PurchaseModel> FromEntitiesList(IEnumerable<Purchase> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Purchase> ToEntitiesList(IEnumerable<PurchaseModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
