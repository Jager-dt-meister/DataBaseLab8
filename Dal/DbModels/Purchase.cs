using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int? BonusId { get; set; }

    public int? ClientId { get; set; }

    public int? SubId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Bonuse Bonus { get; set; }

    public virtual Client Client { get; set; }

    public virtual Sub Sub { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
