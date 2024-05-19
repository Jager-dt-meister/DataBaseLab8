using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Bonuse
	{
		public int BonusId { get; set; }
		public string Name { get; set; }
		public int? Number { get; set; }

		public Bonuse(int bonusId, string name, int? number)
		{
			BonusId = bonusId;
			Name = name;
			Number = number;
		}
	}
}
