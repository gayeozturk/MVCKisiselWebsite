using Microsoft.AspNetCore.Mvc;
using MVCKisiselWebsite.DAL;


namespace MVCKisiselWebsite.Controllers
{
    public class MakaleListViewComponent:ViewComponent
    {
        KisiselwebsiteContext _context;

        public MakaleListViewComponent(KisiselwebsiteContext context)
        {
        _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var makale = _context.Makales.Where(h => h.AktifMi).OrderBy(h => h.Sira).ToList();
            return View(makale);
        }
    }
}
