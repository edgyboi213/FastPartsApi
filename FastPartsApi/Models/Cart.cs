using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastPartsApi.Models;

public partial class Cart
{
    public int IdCart { get; set; }

    public int IdUser { get; set; }

    public int IdPart { get; set; }

    public int Amount { get; set; }

    [JsonIgnore]
    public virtual Part? IdPartNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual User? IdUserNavigation { get; set; } = null!;
}
