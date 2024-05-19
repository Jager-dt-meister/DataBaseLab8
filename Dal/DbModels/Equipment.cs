using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Equipment
{
    public int EqId { get; set; }

    public int? GymId { get; set; }

    public string Name { get; set; }

    public virtual Gym Gym { get; set; }
}
