using System;
using System.Collections.Generic;

namespace FastPartsApi.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdUser { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Orderpart> Orderparts { get; set; } = new List<Orderpart>();
}
