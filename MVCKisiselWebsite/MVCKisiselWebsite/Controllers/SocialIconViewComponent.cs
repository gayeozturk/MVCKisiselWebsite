using Microsoft.AspNetCore.Mvc;
using MVCKisiselWebsite.DAL;

namespace MVCKisiselWebsite.Controllers
{
    public class SocialIconViewComponent:ViewComponent
    {
        KisiselwebsiteContext _context;

        public SocialIconViewComponent(KisiselwebsiteContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bilgi = _context.GenelBilgis.SingleOrDefault();
            return View(bilgi);
        }
    }
}
