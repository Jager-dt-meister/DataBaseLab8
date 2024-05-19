using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Sport
	{
		public int SportId { get; set; }
		public string Name { get; set; }

		public Sport(int sportId, string name)
		{
			SportId = sportId;
			Name = name;
		}
	}
}
