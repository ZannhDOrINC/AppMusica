using System;
using System.Collections.Generic;

namespace AppMusicaV1.Models;

public partial class GenerosMusicales
{
    public short IdGenero { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Albumes> Albumes { get; set; } = new List<Albumes>();
}
