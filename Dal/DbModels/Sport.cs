using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Sport
{
    public int SportId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
