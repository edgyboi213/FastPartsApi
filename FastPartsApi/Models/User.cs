using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastPartsApi.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int IdProfilePhoto { get; set; }

    public string FullName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public string? DeliveryAddress { get; set; }

    [JsonIgnore]
    public virtual ICollection<Cart>? Carts { get; set; } = new List<Cart>();

    [JsonIgnore]
    public virtual Profilephoto? IdProfilePhotoNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();

    [JsonIgnore]
    public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
}
