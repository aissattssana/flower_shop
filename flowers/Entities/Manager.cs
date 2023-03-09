using System;
using System.Collections.Generic;

namespace flowers;

public partial class Manager
{
    public long IdManager { get; set; }

    public long UserId { get; set; }

    public string Position { get; set; } = null!;

    public double Salary { get; set; }

    public virtual User User { get; set; } = null!;
}
