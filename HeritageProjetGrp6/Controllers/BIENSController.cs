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
    public class BIENSController : Controller
    {
        private readonly bdheritageEntities _context;

        public BIENSController(bdheritageEntities context)
        {
            _context = context;
        }

        // GET: BIENS
        public async Task<IActionResult> Index()
        {
            var bdheritageEntities = _context.BIENS.Include(b => b.HERITAGE);
            return View(await bdheritageEntities.ToListAsync());
        }

        // GET: BIENS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bIENS = await _context.BIENS
                .Include(b => b.HERITAGE)
                .FirstOrDefaultAsync(m => m.BIENID == id);
            if (bIENS == null)
            {
                return NotFound();
            }

            return View(bIENS);
        }

        // GET: BIENS/Create
        public IActionResult Create()
        {
            ViewData["HERITAGEID"] = new SelectList(_context.HERITAGE, "HERITAGEID", "HERITAGEID");
            return View();
        }

        // POST: BIENS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BIENID,HERITAGEID,DESCRIPTION,EVALUATEUR,AFFECTATION")] BIENS bIENS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bIENS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HERITAGEID"] = new SelectList(_context.HERITAGE, "HERITAGEID", "HERITAGEID", bIENS.HERITAGEID);
            return View(bIENS);
        }

        // GET: BIENS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bIENS = await _context.BIENS.FindAsync(id);
            if (bIENS == null)
            {
                return NotFound();
            }
            ViewData["HERITAGEID"] = new SelectList(_context.HERITAGE, "HERITAGEID", "HERITAGEID", bIENS.HERITAGEID);
            return View(bIENS);
        }

        // POST: BIENS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BIENID,HERITAGEID,DESCRIPTION,EVALUATEUR,AFFECTATION")] BIENS bIENS)
        {
            if (id != bIENS.BIENID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bIENS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BIENSExists(bIENS.BIENID))
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
            ViewData["HERITAGEID"] = new SelectList(_context.HERITAGE, "HERITAGEID", "HERITAGEID", bIENS.HERITAGEID);
            return View(bIENS);
        }

        // GET: BIENS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bIENS = await _context.BIENS
                .Include(b => b.HERITAGE)
                .FirstOrDefaultAsync(m => m.BIENID == id);
            if (bIENS == null)
            {
                return NotFound();
            }

            return View(bIENS);
        }

        // POST: BIENS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bIENS = await _context.BIENS.FindAsync(id);
            _context.BIENS.Remove(bIENS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BIENSExists(int id)
        {
            return _context.BIENS.Any(e => e.BIENID == id);
        }
    }
}
