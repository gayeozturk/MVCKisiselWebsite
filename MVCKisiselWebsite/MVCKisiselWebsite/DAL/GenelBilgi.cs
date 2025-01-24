using System;
using System.Collections.Generic;

namespace MVCKisiselWebsite.DAL;

public partial class GenelBilgi
{
    public int Id { get; set; }

    public string SiteAdi { get; set; } = null!;

    public string Youtube { get; set; } = null!;

    public string Instagram { get; set; } = null!;

    public string X { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public string Facebook { get; set; } = null!;

    public string Aciklama { get; set; } = null!;

    public string Keyword { get; set; } = null!;

    public string? Logo { get; set; }
}
