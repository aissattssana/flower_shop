using System;
using System.Collections.Generic;

namespace flowers;

public partial class Client
{
    public long IdClient { get; set; }

    public long UserId { get; set; }

    public double Money { get; set; }

    public virtual User User { get; set; } = null!;
}
