using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastPartsApi.Models;

public partial class Oemnumber
{
    public int IdOemNumber { get; set; }

    public string Number { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Part>? Parts { get; set; } = new List<Part>();
}
