using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paluto_Kay_Juan.Models;

namespace Paluto_Kay_Juan.Controllers
{
    public class PkjmenuDbsController : Controller
    {
        private readonly PalutoKayJuanDBContext _context;

        public PkjmenuDbsController(PalutoKayJuanDBContext context)
        {
            _context = context;
        }

        // GET: PkjmenuDbs
        public async Task<IActionResult> Index()
        {
              return _context.PkjmenuDbs != null ? 
                          View(await _context.PkjmenuDbs.ToListAsync()) :
                          Problem("Entity set 'PalutoKayJuanDBContext.PkjmenuDbs'  is null.");
        }

        // GET: PkjmenuDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PkjmenuDbs == null)
            {
                return NotFound();
            }

            var pkjmenuDb = await _context.PkjmenuDbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pkjmenuDb == null)
            {
                return NotFound();
            }

            return View(pkjmenuDb);
        }

        // GET: PkjmenuDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PkjmenuDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FoodName,FoodCategory,QtyPerOrder,PricePerOrder,ImageLocation")] PkjmenuDb pkjmenuDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pkjmenuDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pkjmenuDb);
        }

        // GET: PkjmenuDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PkjmenuDbs == null)
            {
                return NotFound();
            }

            var pkjmenuDb = await _context.PkjmenuDbs.FindAsync(id);
            if (pkjmenuDb == null)
            {
                return NotFound();
            }
            return View(pkjmenuDb);
        }

        // POST: PkjmenuDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FoodName,FoodCategory,QtyPerOrder,PricePerOrder,ImageLocation")] PkjmenuDb pkjmenuDb)
        {
            if (id != pkjmenuDb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pkjmenuDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PkjmenuDbExists(pkjmenuDb.Id))
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
            return View(pkjmenuDb);
        }

        // GET: PkjmenuDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PkjmenuDbs == null)
            {
                return NotFound();
            }

            var pkjmenuDb = await _context.PkjmenuDbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pkjmenuDb == null)
            {
                return NotFound();
            }

            return View(pkjmenuDb);
        }

        // POST: PkjmenuDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PkjmenuDbs == null)
            {
                return Problem("Entity set 'PalutoKayJuanDBContext.PkjmenuDbs'  is null.");
            }
            var pkjmenuDb = await _context.PkjmenuDbs.FindAsync(id);
            if (pkjmenuDb != null)
            {
                _context.PkjmenuDbs.Remove(pkjmenuDb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PkjmenuDbExists(int id)
        {
          return (_context.PkjmenuDbs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
