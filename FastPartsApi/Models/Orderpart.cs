using System;
using System.Collections.Generic;

namespace FastPartsApi.Models;

public partial class Orderpart
{
    public int OrderIdOrder { get; set; }

    public int PartIdPart { get; set; }

    public int Amount { get; set; }

    public virtual Order OrderIdOrderNavigation { get; set; } = null!;

    public virtual Part PartIdPartNavigation { get; set; } = null!;
}
