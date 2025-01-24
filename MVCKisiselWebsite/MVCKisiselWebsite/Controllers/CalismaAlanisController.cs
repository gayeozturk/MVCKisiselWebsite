using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCKisiselWebsite.DAL;
using MVCKisiselWebsite.Filters;

namespace MVCKisiselWebsite.Controllers
{
    [ServiceFilter(typeof(LoginFilter))]
    public class CalismaAlanisController : Controller

    {
        private readonly KisiselwebsiteContext _context;
        //private readonly KisiselwebsiteContext _context=new KisiselwebsiteContext();

        public CalismaAlanisController(KisiselwebsiteContext context) //KisiselwebsiteContext context
        {
            _context = context;
        }

        // GET: CalismaAlanis
        public async Task<IActionResult> Index()
        {
            return View(await _context.CalismaAlanis.ToListAsync());
        }

        // GET: CalismaAlanis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calismaAlani = await _context.CalismaAlanis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calismaAlani == null)
            {
                return NotFound();
            }

            return View(calismaAlani);
        }

        // GET: CalismaAlanis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalismaAlanis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlanAdi,Aciklama")] CalismaAlani calismaAlani)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calismaAlani);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calismaAlani);
        }

        // GET: CalismaAlanis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calismaAlani = await _context.CalismaAlanis.FindAsync(id);
            if (calismaAlani == null)
            {
                return NotFound();
            }
            return View(calismaAlani);
        }

        // POST: CalismaAlanis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlanAdi,Aciklama")] CalismaAlani calismaAlani)
        {
            if (id != calismaAlani.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calismaAlani);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalismaAlaniExists(calismaAlani.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(calismaAlani);
        }

        // GET: CalismaAlanis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calismaAlani = await _context.CalismaAlanis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calismaAlani == null)
            {
                return NotFound();
            }

            return View(calismaAlani);
        }

        // POST: CalismaAlanis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calismaAlani = await _context.CalismaAlanis.FindAsync(id);
            if (calismaAlani != null)
            {
                _context.CalismaAlanis.Remove(calismaAlani);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalismaAlaniExists(int id)
        {
            return _context.CalismaAlanis.Any(e => e.Id == id);
        }
    }
}
