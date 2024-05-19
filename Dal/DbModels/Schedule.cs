using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int? SportId { get; set; }

    public int? TrId { get; set; }

    public int? GymId { get; set; }

    public string Date { get; set; }

    public int? Duration { get; set; }

    public virtual Gym Gym { get; set; }

    public virtual Sport Sport { get; set; }

    public virtual Trainer Tr { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
