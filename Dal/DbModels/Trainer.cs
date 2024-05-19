using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Trainer
{
    public int TrId { get; set; }

    public string Name { get; set; }

    public string Workhours { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
