using System;
using System.Collections.Generic;

namespace MVCKisiselWebsite.DAL;

public partial class Mesaj
{
    public int Id { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Mesajicerik { get; set; } = null!;
}
