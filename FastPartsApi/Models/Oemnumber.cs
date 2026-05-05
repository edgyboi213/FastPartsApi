using System;
using System.Collections.Generic;

namespace FastPartsApi.Models;

public partial class Oemnumber
{
    public int IdOemNumber { get; set; }

    public string Number { get; set; } = null!;

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
