using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastPartsApi.Models;

public partial class Medium
{
    public int IdMedia { get; set; }

    public string Content { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Part>? Parts { get; set; } = new List<Part>();
}
