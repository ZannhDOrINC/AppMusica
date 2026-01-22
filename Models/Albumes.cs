using System;
using System.Collections.Generic;

namespace AppMusicaV1.Models;

public partial class Albumes
{
    public short IdAlbum { get; set; }

    public string NombreArtista { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public short IdGenero { get; set; }

    public int anioLanzamiento { get; set; }

    public virtual GenerosMusicales oGeneroMusical { get; set; } = null!;
}
