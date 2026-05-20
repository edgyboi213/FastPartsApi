using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastPartsApi.Models;

public partial class Profilephoto
{
    public int IdProfilePhoto { get; set; }

    public string Photo { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<User>? Users { get; set; } = new List<User>();
}
