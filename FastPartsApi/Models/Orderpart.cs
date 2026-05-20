using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastPartsApi.Models;

public partial class Orderpart
{
    public int IdOrder { get; set; }

    public int IdPart { get; set; }

    public int Amount { get; set; }

    [JsonIgnore]
    public virtual Order? IdOrderNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Part? IdPartNavigation { get; set; } = null!;
}
