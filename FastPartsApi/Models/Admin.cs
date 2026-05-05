using System;
using System.Collections.Generic;

namespace FastPartsApi.Models;

public partial class Admin
{
    public int IdAdmin { get; set; }

    public string FullName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
