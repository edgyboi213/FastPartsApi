using System;
using System.Collections.Generic;

namespace FastPartsApi.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int IdProfilePhoto { get; set; }

    public string FullName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Profilephoto IdProfilePhotoNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
