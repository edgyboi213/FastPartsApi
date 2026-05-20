using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastPartsApi.Models;

public partial class Part
{
    public int IdPart { get; set; }

    public int IdMedia { get; set; }

    public int IdCategory { get; set; }

    public int IdOemNumber { get; set; }

    public string Name { get; set; } = null!;

    public int Amount { get; set; }

    public string Description { get; set; } = null!;

    public string Weight { get; set; } = null!;

    public string Volume { get; set; } = null!;

    public int? Price { get; set; }

    [JsonIgnore]
    public virtual ICollection<Cart>? Carts { get; set; } = new List<Cart>();

    [JsonIgnore]
    public virtual Category? IdCategoryNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Medium? IdMediaNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Oemnumber? IdOemNumberNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Orderpart>? Orderparts { get; set; } = new List<Orderpart>();

    [JsonIgnore]
    public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
}
