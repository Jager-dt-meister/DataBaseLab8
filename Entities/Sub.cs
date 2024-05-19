using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Sub
	{
		public int SubId { get; set; }
		public string Name { get; set; }
		public int? Price { get; set; }
		public int? Duration { get; set; }

		public Sub(int subId, string name, int? price, int? duration)
		{
			SubId = subId;
			Name = name;
			Price = price;
			Duration = duration;
		}
	}
}
