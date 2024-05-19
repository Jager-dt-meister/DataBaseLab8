using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Purchase
	{
		public int PurchaseId { get; set; }
		public int? BonusId { get; set; }
		public int? ClientId { get; set; }
		public int? SubId { get; set; }
		public DateTime? Date { get; set; }

		public Purchase(int purchaseId, int? bonusId, int? clientId, int? subId, DateTime? date)
		{
			PurchaseId = purchaseId;
			BonusId = bonusId;
			ClientId = clientId;
			SubId = subId;
			Date = date;
		}
	}
}
