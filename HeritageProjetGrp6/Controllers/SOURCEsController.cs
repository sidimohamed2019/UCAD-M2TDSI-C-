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
    public class SOURCEsController : Controller
    {
        private readonly bdheritageEntities _context;

        public SOURCEsController(bdheritageEntities context)
        {
            _context = context;
        }

        // GET: SOURCEs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SOURCE.ToListAsync());
        }

        // GET: SOURCEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sOURCE = await _context.SOURCE
                .FirstOrDefaultAsync(m => m.SOURCEID == id);
            if (sOURCE == null)
            {
                return NotFound();
            }

            return View(sOURCE);
        }

        // GET: SOURCEs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SOURCEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SOURCEID,DESIGNATION,HIERARCHIEID,COMMENTAIRE")] SOURCE sOURCE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sOURCE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sOURCE);
        }

        // GET: SOURCEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sOURCE = await _context.SOURCE.FindAsync(id);
            if (sOURCE == null)
            {
                return NotFound();
            }
            return View(sOURCE);
        }

        // POST: SOURCEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SOURCEID,DESIGNATION,HIERARCHIEID,COMMENTAIRE")] SOURCE sOURCE)
        {
            if (id != sOURCE.SOURCEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sOURCE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SOURCEExists(sOURCE.SOURCEID))
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
            return View(sOURCE);
        }

        // GET: SOURCEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sOURCE = await _context.SOURCE
                .FirstOrDefaultAsync(m => m.SOURCEID == id);
            if (sOURCE == null)
            {
                return NotFound();
            }

            return View(sOURCE);
        }

        // POST: SOURCEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sOURCE = await _context.SOURCE.FindAsync(id);
            _context.SOURCE.Remove(sOURCE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SOURCEExists(int id)
        {
            return _context.SOURCE.Any(e => e.SOURCEID == id);
        }
    }
}
