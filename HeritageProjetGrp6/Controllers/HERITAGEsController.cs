using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeritageProjectGrp6.Models;
using HeritageProjetGrp6.Models;

namespace HeritageProjetGrp6.Controllers
{
    public class HERITAGEsController : Controller
    {
        private readonly bdheritageEntities _context;

        public HERITAGEsController(bdheritageEntities context)
        {
            _context = context;
        }

        // GET: HERITAGEs
        public async Task<IActionResult> Index()
        {
            var bdheritageEntities = _context.HERITAGE.Include(h => h.HERITIER);
            return View(await bdheritageEntities.ToListAsync());
        }

        // GET: HERITAGEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hERITAGE = await _context.HERITAGE
                .Include(h => h.HERITIER)
                .FirstOrDefaultAsync(m => m.HERITAGEID == id);
            if (hERITAGE == null)
            {
                return NotFound();
            }

            return View(hERITAGE);
        }

        // GET: HERITAGEs/Create
        public IActionResult Create()
        {
            ViewData["NOMENCLATUREID"] = new SelectList(_context.HERITIER, "NOMENCLATUREID", "NOMENCLATUREID");
            return View();
        }

        // POST: HERITAGEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HERITAGEID,NOMENCLATUREID,DESCRIPTION,DATE_DECES,DATE_HERITAGE,ECOLEID,MONTANT")] HERITAGE hERITAGE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hERITAGE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NOMENCLATUREID"] = new SelectList(_context.HERITIER, "NOMENCLATUREID", "NOMENCLATUREID", hERITAGE.NOMENCLATUREID);
            return View(hERITAGE);
        }

        // GET: HERITAGEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hERITAGE = await _context.HERITAGE.FindAsync(id);
            if (hERITAGE == null)
            {
                return NotFound();
            }
            ViewData["NOMENCLATUREID"] = new SelectList(_context.HERITIER, "NOMENCLATUREID", "NOMENCLATUREID", hERITAGE.NOMENCLATUREID);
            return View(hERITAGE);
        }

        // POST: HERITAGEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HERITAGEID,NOMENCLATUREID,DESCRIPTION,DATE_DECES,DATE_HERITAGE,ECOLEID,MONTANT")] HERITAGE hERITAGE)
        {
            if (id != hERITAGE.HERITAGEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hERITAGE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HERITAGEExists(hERITAGE.HERITAGEID))
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
            ViewData["NOMENCLATUREID"] = new SelectList(_context.HERITIER, "NOMENCLATUREID", "NOMENCLATUREID", hERITAGE.NOMENCLATUREID);
            return View(hERITAGE);
        }

        // GET: HERITAGEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hERITAGE = await _context.HERITAGE
                .Include(h => h.HERITIER)
                .FirstOrDefaultAsync(m => m.HERITAGEID == id);
            if (hERITAGE == null)
            {
                return NotFound();
            }

            return View(hERITAGE);
        }

        // POST: HERITAGEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hERITAGE = await _context.HERITAGE.FindAsync(id);
            _context.HERITAGE.Remove(hERITAGE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HERITAGEExists(int id)
        {
            return _context.HERITAGE.Any(e => e.HERITAGEID == id);
        }
    }
}
