using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MVCKisiselWebsite.DAL;
using MVCKisiselWebsite.Filters;
using MVCKisiselWebsite.Models;

namespace MVCKisiselWebsite.Controllers
{   
    public class AdminController : Controller
    {
        private readonly KisiselwebsiteContext _context;

        public AdminController(KisiselwebsiteContext context)
        {
            _context = context;
        }

        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult Index()
        {   
            //if (!HttpContext.Session.Keys.Contains("username"))
            //    return RedirectToAction("Login");
            //session

            var user = HttpContext.Session.GetString("username");
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var kullanici = _context.Kullanicis.Where(h => h.Sifre == model.password && h.Email == model.username).SingleOrDefault();

            if (kullanici != null)
            {

                HttpContext.Session.SetString("username", model.username);
                return RedirectToAction("Index");
                
                
            }
            ViewBag.mesaj = "Kullanıcı adı veya şifre yanlış";
            
            return View(model);
        }
    }
}
