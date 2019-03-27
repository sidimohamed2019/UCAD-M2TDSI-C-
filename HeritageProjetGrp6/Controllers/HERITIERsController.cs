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
    public class HERITIERsController : Controller
    {
        private readonly bdheritageEntities _context;

        public HERITIERsController(bdheritageEntities context)
        {
            _context = context;
        }

        // GET: HERITIERs
        public async Task<IActionResult> Index()
        {
            return View(await _context.HERITIER.ToListAsync());
        }

        // GET: HERITIERs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hERITIER = await _context.HERITIER
                .FirstOrDefaultAsync(m => m.NOMENCLATUREID == id);
            if (hERITIER == null)
            {
                return NotFound();
            }

            return View(hERITIER);
        }

        // GET: HERITIERs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HERITIERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NOMENCLATUREID,DESCRIPTION,CODE,ILLLUSTRATION")] HERITIER hERITIER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hERITIER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hERITIER);
        }

        // GET: HERITIERs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hERITIER = await _context.HERITIER.FindAsync(id);
            if (hERITIER == null)
            {
                return NotFound();
            }
            return View(hERITIER);
        }

        // POST: HERITIERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NOMENCLATUREID,DESCRIPTION,CODE,ILLLUSTRATION")] HERITIER hERITIER)
        {
            if (id != hERITIER.NOMENCLATUREID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hERITIER);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HERITIERExists(hERITIER.NOMENCLATUREID))
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
            return View(hERITIER);
        }

        // GET: HERITIERs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hERITIER = await _context.HERITIER
                .FirstOrDefaultAsync(m => m.NOMENCLATUREID == id);
            if (hERITIER == null)
            {
                return NotFound();
            }

            return View(hERITIER);
        }

        // POST: HERITIERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hERITIER = await _context.HERITIER.FindAsync(id);
            _context.HERITIER.Remove(hERITIER);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HERITIERExists(int id)
        {
            return _context.HERITIER.Any(e => e.NOMENCLATUREID == id);
        }
    }
}
