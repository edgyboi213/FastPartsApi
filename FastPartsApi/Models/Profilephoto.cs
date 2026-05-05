using System;
using System.Collections.Generic;

namespace FastPartsApi.Models;

public partial class Profilephoto
{
    public int IdProfilePhoto { get; set; }

    public string Photo { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
