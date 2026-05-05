using System;
using System.Collections.Generic;

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

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Medium IdMediaNavigation { get; set; } = null!;

    public virtual Oemnumber IdOemNumberNavigation { get; set; } = null!;

    public virtual ICollection<Orderpart> Orderparts { get; set; } = new List<Orderpart>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
