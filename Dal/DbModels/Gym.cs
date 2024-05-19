using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Gym
{
    public int GymId { get; set; }

    public int? SportId { get; set; }

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
