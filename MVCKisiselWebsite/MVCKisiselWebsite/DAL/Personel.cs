using System;
using System.Collections.Generic;

namespace MVCKisiselWebsite.DAL;

public partial class Personel
{
    public int Id { get; set; }

    public string? Yol { get; set; }

    public int? Sira { get; set; }

    public string? Unvan { get; set; }

    public string? Ad { get; set; }

    public bool? AktifMi { get; set; }
}
