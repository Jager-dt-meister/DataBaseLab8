using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Gym
	{
		public int GymId { get; set; }
		public int? SportId { get; set; }

		public Gym(int gymId, int? sportId)
		{
			GymId = gymId;
			SportId = sportId;
		}
	}
}
