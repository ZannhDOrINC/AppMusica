using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppMusicaV1.Models;
using AppMusicaV1.Models.ViewModels;
using System.Diagnostics;

namespace AppMusicaV1.Controllers;

public class HomeController : Controller
{
    private readonly AppMusicaContext _DBContext;

    public HomeController(AppMusicaContext context)
    {
        _DBContext = context;
    }

    public IActionResult Index()
    {
        List<Albumes> _albumesM = _DBContext.Albumes.Include(a => a.oGeneroMusical).ToList();

        return View(_albumesM);
    }

    [HttpGet]
    public IActionResult Album_Detalle(int idAlbum)
    {
        AlbumVM oGenAlbum = new AlbumVM()
        {
            oAlbum = new Albumes(),
            oListaGenero = _DBContext.GenerosMusicales.Select(genero => new SelectListItem()
            {
                Value = genero.IdGenero.ToString(),
                Text = genero.Nombre
            }).ToList()
        };

        if (idAlbum != 0) {
            oGenAlbum.oAlbum = _DBContext.Albumes.Find((short)idAlbum);
        }

        return View(oGenAlbum);
    }

    [HttpPost]
    public IActionResult Album_Detalle(AlbumVM oAlbumVM)
    {
        if (oAlbumVM.oAlbum.IdAlbum == 0)
        {
            _DBContext.Albumes.Add(oAlbumVM.oAlbum); // esto ingresa los nuevos datos en la base de datos como si fuera INSERT
        }
        else
        {
            _DBContext.Albumes.Update(oAlbumVM.oAlbum); //esto actualizara la base de datos como si se utilizara un UPDATE
        }

        _DBContext.SaveChanges(); // guarda los cambios en la base de datos 

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Eliminar_Album(int idAlbum)
    {
        Albumes oAlbum = _DBContext.Albumes.Include(c => c.oGeneroMusical).Where(e => e.IdAlbum == idAlbum).FirstOrDefault();

        return View(oAlbum);
    }

    [HttpPost]
    public IActionResult Eliminar_Album(Albumes oAlbum)
    {
        _DBContext.Albumes.Remove(oAlbum);

        _DBContext.SaveChanges();

        return RedirectToAction("Index", "Home");
    }
}