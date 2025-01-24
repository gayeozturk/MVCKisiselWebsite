using Microsoft.AspNetCore.Mvc;
using MVCKisiselWebsite.DAL;

namespace MVCKisiselWebsite.Controllers
{
    public class GenelBilgiController : Controller
    {
        private KisiselwebsiteContext _context;

        public GenelBilgiController(KisiselwebsiteContext context)
        { 
        _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.GenelBilgis.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Index(int Id,GenelBilgi model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return View(model);
        }
    }
}
