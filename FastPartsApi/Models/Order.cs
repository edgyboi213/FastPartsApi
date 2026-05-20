using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastPartsApi.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdUser { get; set; }

    public DateTime OrderDate { get; set; }

    [JsonIgnore]
    public virtual User? IdUserNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Orderpart>? Orderparts { get; set; } = new List<Orderpart>();
}
