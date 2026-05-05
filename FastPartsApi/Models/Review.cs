using System;
using System.Collections.Generic;

namespace FastPartsApi.Models;

public partial class Review
{
    public int IdReview { get; set; }

    public int IdPart { get; set; }

    public int IdUser { get; set; }

    public string ReviewText { get; set; } = null!;

    public int Rating { get; set; }

    public virtual Part IdPartNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
