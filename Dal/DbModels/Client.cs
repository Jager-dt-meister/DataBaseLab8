using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Client
{
    public int ClientId { get; set; }

    public string Name { get; set; }

    public DateTime? Birth { get; set; }

    public DateTime? RegDate { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
