using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Trainer
	{
		public int TrId { get; set; }
		public string Name { get; set; }
		public string Workhours { get; set; }

		public Trainer(int trId, string name, string workhours)
		{
			TrId = trId;
			Name = name;
			Workhours = workhours;
		}
	}
}
