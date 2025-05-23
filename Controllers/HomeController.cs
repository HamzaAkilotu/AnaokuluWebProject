using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AnaOkuluYS.Models;
using System.Collections.Generic;

namespace AnaOkuluYS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Hakkimizda()
    {
        return View();
    }

    public IActionResult BransDerslerimiz()
    {
        return View();
    }

    public IActionResult YaptigimizEtkinlikler()
    {
        return View();
    }

    public IActionResult IsBasvurusu()
    {
        return View();
    }

    public IActionResult Okulumuz()
    {
        return View();
    }

    public IActionResult EgitimKadromuz()
    {
        return View();
    }

    public IActionResult HaftalikYemekListesi()
    {
        return View();
    }

    public IActionResult RehberlikDestegi()
    {
        return View("RehberlikDestegi");
    }

    public IActionResult OkulServisi()
    {
        return View();
    }

    public IActionResult Galeri()
    {
        // Örnek galeri verileri
        var galeri = new List<Galeri>
        {
            new Galeri { Id = 1, Baslik = "23 Nisan Kutlaması", Aciklama = "23 Nisan Ulusal Egemenlik ve Çocuk Bayramı kutlamalarımızdan kareler", ResimYolu = "/images/galeri/23nisan.jpg" },
            new Galeri { Id = 2, Baslik = "Sanat Atölyesi", Aciklama = "Çocuklarımızın sanat çalışmaları", ResimYolu = "/images/galeri/sanat.jpg" },
            new Galeri { Id = 3, Baslik = "Doğa Gezisi", Aciklama = "Doğa yürüyüşü ve piknik etkinliğimiz", ResimYolu = "/images/galeri/doga.jpg" },
            new Galeri { Id = 4, Baslik = "Müzik Dersi", Aciklama = "Müzik dersimizden kareler", ResimYolu = "/images/galeri/muzik.jpg" }
        };

        return View(galeri);
    }

    public IActionResult Iletisim()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}