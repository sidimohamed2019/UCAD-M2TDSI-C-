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
    public class AYANTDROITsController : Controller
    {
        private readonly bdheritageEntities _context;

        public AYANTDROITsController(bdheritageEntities context)
        {
            _context = context;
        }

        // GET: AYANTDROITs
        public async Task<IActionResult> Index()
        {
            var bdheritageEntities = _context.AYANTDROIT.Include(a => a.HERITIER).Include(a => a.UTILISATEUR);
            return View(await bdheritageEntities.ToListAsync());
        }

        // GET: AYANTDROITs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aYANTDROIT = await _context.AYANTDROIT
                .Include(a => a.HERITIER)
                .Include(a => a.UTILISATEUR)
                .FirstOrDefaultAsync(m => m.ADRID == id);
            if (aYANTDROIT == null)
            {
                return NotFound();
            }

            return View(aYANTDROIT);
        }

        // GET: AYANTDROITs/Create
        public IActionResult Create()
        {
            ViewData["NOMENCLATUREID"] = new SelectList(_context.HERITIER, "NOMENCLATUREID", "NOMENCLATUREID");
            ViewData["UTILISATEURID"] = new SelectList(_context.UTILISATEUR, "UTILISATEURID", "UTILISATEURID");
            return View();
        }

        // POST: AYANTDROITs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ADRID,NOMENCLATUREID,UTILISATEURID,DESIGNATION,IMAGEADR,DESCRIPTION,DATECREATION,TYPEHERITIER,NOM,PRENOM,DATENAISSANCE,SEXE")] AYANTDROIT aYANTDROIT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aYANTDROIT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NOMENCLATUREID"] = new SelectList(_context.HERITIER, "NOMENCLATUREID", "NOMENCLATUREID", aYANTDROIT.NOMENCLATUREID);
            ViewData["UTILISATEURID"] = new SelectList(_context.UTILISATEUR, "UTILISATEURID", "UTILISATEURID", aYANTDROIT.UTILISATEURID);
            return View(aYANTDROIT);
        }

        // GET: AYANTDROITs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aYANTDROIT = await _context.AYANTDROIT.FindAsync(id);
            if (aYANTDROIT == null)
            {
                return NotFound();
            }
            ViewData["NOMENCLATUREID"] = new SelectList(_context.HERITIER, "NOMENCLATUREID", "NOMENCLATUREID", aYANTDROIT.NOMENCLATUREID);
            ViewData["UTILISATEURID"] = new SelectList(_context.UTILISATEUR, "UTILISATEURID", "UTILISATEURID", aYANTDROIT.UTILISATEURID);
            return View(aYANTDROIT);
        }

        // POST: AYANTDROITs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ADRID,NOMENCLATUREID,UTILISATEURID,DESIGNATION,IMAGEADR,DESCRIPTION,DATECREATION,TYPEHERITIER,NOM,PRENOM,DATENAISSANCE,SEXE")] AYANTDROIT aYANTDROIT)
        {
            if (id != aYANTDROIT.ADRID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aYANTDROIT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AYANTDROITExists(aYANTDROIT.ADRID))
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
            ViewData["NOMENCLATUREID"] = new SelectList(_context.HERITIER, "NOMENCLATUREID", "NOMENCLATUREID", aYANTDROIT.NOMENCLATUREID);
            ViewData["UTILISATEURID"] = new SelectList(_context.UTILISATEUR, "UTILISATEURID", "UTILISATEURID", aYANTDROIT.UTILISATEURID);
            return View(aYANTDROIT);
        }

        // GET: AYANTDROITs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aYANTDROIT = await _context.AYANTDROIT
                .Include(a => a.HERITIER)
                .Include(a => a.UTILISATEUR)
                .FirstOrDefaultAsync(m => m.ADRID == id);
            if (aYANTDROIT == null)
            {
                return NotFound();
            }

            return View(aYANTDROIT);
        }

        // POST: AYANTDROITs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aYANTDROIT = await _context.AYANTDROIT.FindAsync(id);
            _context.AYANTDROIT.Remove(aYANTDROIT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AYANTDROITExists(int id)
        {
            return _context.AYANTDROIT.Any(e => e.ADRID == id);
        }
    }
}
