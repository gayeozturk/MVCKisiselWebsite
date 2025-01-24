using System;
using System.Collections.Generic;

namespace MVCKisiselWebsite.DAL;

public partial class Video
{
    public int Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Aciklama { get; set; } = null!;

    public string Iframe { get; set; } = null!;

    public bool? AktifMi { get; set; }

    public int? Sira { get; set; }
}
