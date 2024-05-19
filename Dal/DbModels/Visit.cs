using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Visit
{
    public int VisitId { get; set; }

    public int? ScheduleId { get; set; }

    public int? PurchaseId { get; set; }

    public DateTime? Realdate { get; set; }

    public virtual Purchase Purchase { get; set; }

    public virtual Schedule Schedule { get; set; }
}
