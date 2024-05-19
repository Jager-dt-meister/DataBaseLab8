using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Schedule
	{
		public int ScheduleId { get; set; }
		public int? SportId { get; set; }
		public int? TrId { get; set; }
		public int? GymId { get; set; }
		public string Date { get; set; }
		public int? Duration { get; set; }

		public Schedule(int scheduleId, int? sportId, int? trId, int? gymId, string date, int? duration)
		{
			ScheduleId = scheduleId;
			SportId = sportId;
			TrId = trId;
			GymId = gymId;
			Date = date;
			Duration = duration;
		}
	}
}
