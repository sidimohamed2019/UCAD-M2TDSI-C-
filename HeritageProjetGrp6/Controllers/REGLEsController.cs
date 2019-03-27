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
    public class REGLEsController : Controller
    {
        private readonly bdheritageEntities _context;

        public REGLEsController(bdheritageEntities context)
        {
            _context = context;
        }

        // GET: REGLEs
        public async Task<IActionResult> Index()
        {
            var bdheritageEntities = _context.REGLE.Include(r => r.SOURCE);
            return View(await bdheritageEntities.ToListAsync());
        }

        // GET: REGLEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEGLE = await _context.REGLE
                .Include(r => r.SOURCE)
                .FirstOrDefaultAsync(m => m.REGLEID == id);
            if (rEGLE == null)
            {
                return NotFound();
            }

            return View(rEGLE);
        }

        // GET: REGLEs/Create
        public IActionResult Create()
        {
            ViewData["SOURCEID"] = new SelectList(_context.SOURCE, "SOURCEID", "SOURCEID");
            return View();
        }

        // POST: REGLEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("REGLEID,SOURCEID,DESCRIPTION,ECOLES,COMMENTAIRE")] REGLE rEGLE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rEGLE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SOURCEID"] = new SelectList(_context.SOURCE, "SOURCEID", "SOURCEID", rEGLE.SOURCEID);
            return View(rEGLE);
        }

        // GET: REGLEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEGLE = await _context.REGLE.FindAsync(id);
            if (rEGLE == null)
            {
                return NotFound();
            }
            ViewData["SOURCEID"] = new SelectList(_context.SOURCE, "SOURCEID", "SOURCEID", rEGLE.SOURCEID);
            return View(rEGLE);
        }

        // POST: REGLEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("REGLEID,SOURCEID,DESCRIPTION,ECOLES,COMMENTAIRE")] REGLE rEGLE)
        {
            if (id != rEGLE.REGLEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rEGLE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!REGLEExists(rEGLE.REGLEID))
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
            ViewData["SOURCEID"] = new SelectList(_context.SOURCE, "SOURCEID", "SOURCEID", rEGLE.SOURCEID);
            return View(rEGLE);
        }

        // GET: REGLEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEGLE = await _context.REGLE
                .Include(r => r.SOURCE)
                .FirstOrDefaultAsync(m => m.REGLEID == id);
            if (rEGLE == null)
            {
                return NotFound();
            }

            return View(rEGLE);
        }

        // POST: REGLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rEGLE = await _context.REGLE.FindAsync(id);
            _context.REGLE.Remove(rEGLE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool REGLEExists(int id)
        {
            return _context.REGLE.Any(e => e.REGLEID == id);
        }
    }
}
