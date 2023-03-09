using System;
using System.Collections.Generic;

namespace flowers;

public partial class Catalog
{
    public long IdTovar { get; set; }

    public long Quantity { get; set; }

    public string Name { get; set; } = null!;

    public string Text { get; set; } = null!;

    public double Cost { get; set; }

    public string Type { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public virtual ICollection<OrderCatalog> OrderCatalogs { get; } = new List<OrderCatalog>();
}
