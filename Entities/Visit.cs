using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Visit
	{
		public int VisitId { get; set; }
		public int? ScheduleId { get; set; }
		public int? PurchaseId { get; set; }
		public DateTime? Realdate { get; set; }

		public Visit(int visitId, int? scheduleId, int? purchaseId, DateTime? realdate)
		{
			VisitId = visitId;
			ScheduleId = scheduleId;
			PurchaseId = purchaseId;
			Realdate = realdate;
		}
	}
}
