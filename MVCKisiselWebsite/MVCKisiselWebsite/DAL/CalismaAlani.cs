using System;
using System.Collections.Generic;

namespace MVCKisiselWebsite.DAL;

public partial class CalismaAlani
{
    public int Id { get; set; }

    public string AlanAdi { get; set; } = null!;

    public string Aciklama { get; set; } = null!;
}
