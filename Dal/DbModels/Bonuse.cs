using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Bonuse
{
    public int BonusId { get; set; }

    public string Name { get; set; }

    public int? Number { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
