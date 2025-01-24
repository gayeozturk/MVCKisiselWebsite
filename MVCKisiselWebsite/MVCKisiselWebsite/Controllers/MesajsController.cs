using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCKisiselWebsite.DAL;

namespace MVCKisiselWebsite.Controllers
{
    public class MesajsController : Controller
    {
        private readonly KisiselwebsiteContext _context;

        public MesajsController(KisiselwebsiteContext context)
        {
            _context = context;
        }

        // GET: Mesajs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mesajs.ToListAsync());
        }

        // GET: Mesajs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesaj = await _context.Mesajs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mesaj == null)
            {
                return NotFound();
            }

            return View(mesaj);
        }

        // GET: Mesajs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mesajs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdSoyad,Mail,Mesajicerik")] Mesaj mesaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesaj);
        }

        // GET: Mesajs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesaj = await _context.Mesajs.FindAsync(id);
            if (mesaj == null)
            {
                return NotFound();
            }
            return View(mesaj);
        }

        // POST: Mesajs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,Mail,Mesajicerik")] Mesaj mesaj)
        {
            if (id != mesaj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesajExists(mesaj.Id))
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
            return View(mesaj);
        }

        // GET: Mesajs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesaj = await _context.Mesajs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mesaj == null)
            {
                return NotFound();
            }

            return View(mesaj);
        }

        // POST: Mesajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mesaj = await _context.Mesajs.FindAsync(id);
            if (mesaj != null)
            {
                _context.Mesajs.Remove(mesaj);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesajExists(int id)
        {
            return _context.Mesajs.Any(e => e.Id == id);
        }
    }
}
