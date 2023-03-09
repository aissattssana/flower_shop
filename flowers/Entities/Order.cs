using System;
using System.Collections.Generic;

namespace flowers;

public partial class Order
{
    public long IdOrder { get; set; }

    public long ClientId { get; set; }

    public string Address { get; set; } = null!;

    public byte[] Date { get; set; } = null!;

    public virtual ICollection<OrderCatalog> OrderCatalogs { get; } = new List<OrderCatalog>();
}
