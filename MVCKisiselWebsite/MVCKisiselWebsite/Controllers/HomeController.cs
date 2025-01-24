using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCKisiselWebsite.DAL;
using MVCKisiselWebsite.Filters;
using MVCKisiselWebsite.Models;
using System.Diagnostics;

namespace MVCKisiselWebsite.Controllers
{
    [ServiceFilter(typeof(LogFilter))]
    public class HomeController : Controller
    {
        KisiselwebsiteContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,KisiselwebsiteContext db)
        {
            _logger = logger;
            this.db = db;
        }

        
        public IActionResult Index()
        {
            //var sliders = db.Sliders.ToList();
            var calani = db.CalismaAlanis.ToList();
            var sliders=db.Sliders.Where(h=>h.AktifMi).OrderBy(h=>h.Sira).ToList();
            var videos = db.Videos.ToList();

            var model = new IndexViewModel();

            model.Slider = sliders;
            model.CalismaAlani = calani;
            model.Video = videos;
            //var model = new IndexViewModel{
            //    Sliders = db.Sliders.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList(),
            //    CalismaAlanlari = db.CalismaAlanis.ToList()
            //};

            //ViewBag.Aciklama = calani.SingleOrDefault(h => h.Id == Id).Aciklama;
            //ViewBag.AlanAdi = calani.SingleOrDefault(h => h.Id == Id).AlanAdi;

            return View(model) ;
           
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult CalismaAlanlari(int Id)
        {
            //ÝNT DEÐER ALMAMIÞÞSA SIFIR
            var calisma = db.CalismaAlanis.ToList();
            if (Id == 0)
            {
                ViewBag.Aciklama = calisma.FirstOrDefault().Aciklama;
                ViewBag.AlanAdi = calisma.FirstOrDefault().AlanAdi;

            }
            else {

            ViewBag.Aciklama = calisma.SingleOrDefault(h=>h.Id==Id).Aciklama;
            ViewBag.AlanAdi = calisma.SingleOrDefault(h => h.Id == Id).AlanAdi;

             }
            return View(calisma);
        }

        public IActionResult Makaleler()
        {
            var makaleler = db.Makales.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();
            return View(makaleler);
        }

        public IActionResult MakaleDetay(int Id)
        {
            var makaleler = db.Makales.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();
            ViewBag.Makale = makaleler.SingleOrDefault(h => h.Id == Id);
            //ViewBag.Icerik = makaleler.SingleOrDefault(h => h.Id == Id).Icerik;
            return View();
            //parçalý view ve component ile de yapabiliriz 
        }

        [HttpPost]

        public JsonResult Like(int Id)
        {
            var m = db.Makales.Find(Id);
            m.Likee++;
            db.SaveChanges();

            return Json(m.Likee);
        }

        [HttpPost]
        public JsonResult DisLike(int Id)
        {
            var m = db.Makales.Find(Id);
            m.Dislike++;
            db.SaveChanges();
            return Json(m.Dislike);

        }

        public IActionResult Iletisim()
        {
            //throw new Exception("Özel hata denmesi");
            return View(db.GenelBilgis.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Mesaj(Mesaj formData)
        {
            db.Mesajs.Add(formData);
            db.SaveChanges();
            //throw new Exception("Özel hata denmesi");
            return Json("Mesajýnýz kaydedildi");
        }
        public IActionResult Kadromuz()
        {
            var personel = db.Personels.ToList();
            return View(personel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
