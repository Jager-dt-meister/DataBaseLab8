using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Sub
{
    public int SubId { get; set; }

    public string Name { get; set; }

    public int? Price { get; set; }

    public int? Duration { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
