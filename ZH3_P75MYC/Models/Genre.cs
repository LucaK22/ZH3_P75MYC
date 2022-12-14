using System;
using System.Collections.Generic;

namespace ZH3_P75MYC.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Genre1 { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
