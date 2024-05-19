using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Equipment
	{
		public int EqId { get; set; }
		public int? GymId { get; set; }
		public string Name { get; set; }

		public Equipment(int eqId, int? gymId, string name)
		{
			EqId = eqId;
			GymId = gymId;
			Name = name;
		}
	}
}
