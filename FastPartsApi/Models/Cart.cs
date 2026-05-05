using System;
using System.Collections.Generic;

namespace FastPartsApi.Models;

public partial class Cart
{
    public int IdCart { get; set; }

    public int IdUser { get; set; }

    public int IdPart { get; set; }

    public int Amount { get; set; }

    public virtual Part IdPartNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
