using System;
using System.Collections.Generic;

namespace ZH3_P75MYC.Models;

public partial class Studio
{
    public int StudioId { get; set; }

    public string Studio1 { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
