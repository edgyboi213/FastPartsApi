using System;
using System.Collections.Generic;

namespace FastPartsApi.Models;

public partial class Medium
{
    public int IdMedia { get; set; }

    public string Content { get; set; } = null!;

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
