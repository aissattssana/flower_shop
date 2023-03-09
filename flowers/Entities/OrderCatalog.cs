using System;
using System.Collections.Generic;

namespace flowers;

public partial class OrderCatalog
{
    public long IdOrderCatalog { get; set; }

    public long TovarId { get; set; }

    public long OrderId { get; set; }

    public long Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Catalog Tovar { get; set; } = null!;
}
