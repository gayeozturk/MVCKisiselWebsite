using System;
using System.Collections.Generic;

namespace MVCKisiselWebsite.DAL;

public partial class Makale
{
    public int Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Icerik { get; set; } = null!;

    public int Sira { get; set; }

    public bool AktifMi { get; set; }

    public int? Dislike { get; set; }

    public int? Likee { get; set; }
}
