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
    public class ECOLEsController : Controller
    {
        private readonly bdheritageEntities _context;

        public ECOLEsController(bdheritageEntities context)
        {
            _context = context;
        }

        // GET: ECOLEs
        public async Task<IActionResult> Index()
        {
            var bdheritageEntities = _context.ECOLE.Include(e => e.HERITAGE).Include(e => e.REGLE);
            return View(await bdheritageEntities.ToListAsync());
        }

        // GET: ECOLEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCOLE = await _context.ECOLE
                .Include(e => e.HERITAGE)
                .Include(e => e.REGLE)
                .FirstOrDefaultAsync(m => m.ECOLEID == id);
            if (eCOLE == null)
            {
                return NotFound();
            }

            return View(eCOLE);
        }

        // GET: ECOLEs/Create
        public IActionResult Create()
        {
            ViewData["HERITAGEID"] = new SelectList(_context.HERITAGE, "HERITAGEID", "HERITAGEID");
            ViewData["REGLEID"] = new SelectList(_context.REGLE, "REGLEID", "REGLEID");
            return View();
        }

        // POST: ECOLEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ECOLEID,HERITAGEID,REGLEID,NOM,DESCRIPTION")] ECOLE eCOLE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eCOLE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HERITAGEID"] = new SelectList(_context.HERITAGE, "HERITAGEID", "HERITAGEID", eCOLE.HERITAGEID);
            ViewData["REGLEID"] = new SelectList(_context.REGLE, "REGLEID", "REGLEID", eCOLE.REGLEID);
            return View(eCOLE);
        }

        // GET: ECOLEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCOLE = await _context.ECOLE.FindAsync(id);
            if (eCOLE == null)
            {
                return NotFound();
            }
            ViewData["HERITAGEID"] = new SelectList(_context.HERITAGE, "HERITAGEID", "HERITAGEID", eCOLE.HERITAGEID);
            ViewData["REGLEID"] = new SelectList(_context.REGLE, "REGLEID", "REGLEID", eCOLE.REGLEID);
            return View(eCOLE);
        }

        // POST: ECOLEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ECOLEID,HERITAGEID,REGLEID,NOM,DESCRIPTION")] ECOLE eCOLE)
        {
            if (id != eCOLE.ECOLEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eCOLE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ECOLEExists(eCOLE.ECOLEID))
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
            ViewData["HERITAGEID"] = new SelectList(_context.HERITAGE, "HERITAGEID", "HERITAGEID", eCOLE.HERITAGEID);
            ViewData["REGLEID"] = new SelectList(_context.REGLE, "REGLEID", "REGLEID", eCOLE.REGLEID);
            return View(eCOLE);
        }

        // GET: ECOLEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCOLE = await _context.ECOLE
                .Include(e => e.HERITAGE)
                .Include(e => e.REGLE)
                .FirstOrDefaultAsync(m => m.ECOLEID == id);
            if (eCOLE == null)
            {
                return NotFound();
            }

            return View(eCOLE);
        }

        // POST: ECOLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eCOLE = await _context.ECOLE.FindAsync(id);
            _context.ECOLE.Remove(eCOLE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ECOLEExists(int id)
        {
            return _context.ECOLE.Any(e => e.ECOLEID == id);
        }
    }
}
