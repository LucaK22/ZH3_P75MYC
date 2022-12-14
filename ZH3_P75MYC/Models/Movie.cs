using System;
using System.Collections.Generic;

namespace ZH3_P75MYC.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? GenreId { get; set; }

    public int? StudioId { get; set; }

    public int? AudienceScore { get; set; }

    public int Year { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual Studio? Studio { get; set; }
}
