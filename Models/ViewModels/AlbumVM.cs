using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppMusicaV1.Models.ViewModels
{
    public class AlbumVM
    {
        public Albumes oAlbum { get; set; }

        public List<SelectListItem> oListaGenero { get; set; }
    }
}
