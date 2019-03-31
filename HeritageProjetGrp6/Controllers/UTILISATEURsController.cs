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
    public class UTILISATEURsController : Controller
    {
        private readonly bdheritageEntities _context;

        public UTILISATEURsController(bdheritageEntities context)
        {
            _context = context;
        }

        // GET: UTILISATEURs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UTILISATEUR.ToListAsync());
        }

        // GET: UTILISATEURs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uTILISATEUR = await _context.UTILISATEUR
                .FirstOrDefaultAsync(m => m.UTILISATEURID == id);
            if (uTILISATEUR == null)
            {
                return NotFound();
            }

            return View(uTILISATEUR);
        }

        // GET: UTILISATEURs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UTILISATEURs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UTILISATEURID,UTI_UTILISATEURID,DESIGNATION,EMAIL,PWD,TYPEUTILISATEUR")] UTILISATEUR uTILISATEUR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uTILISATEUR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uTILISATEUR);
        }

        // GET: UTILISATEURs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uTILISATEUR = await _context.UTILISATEUR.FindAsync(id);
            if (uTILISATEUR == null)
            {
                return NotFound();
            }
            return View(uTILISATEUR);
        }

        // POST: UTILISATEURs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UTILISATEURID,UTI_UTILISATEURID,DESIGNATION,EMAIL,TYPEUTILISATEUR")] UTILISATEUR uTILISATEUR)
        {
            if (id != uTILISATEUR.UTILISATEURID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uTILISATEUR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UTILISATEURExists(uTILISATEUR.UTILISATEURID))
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
            return View(uTILISATEUR);
        }

        // GET: UTILISATEURs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uTILISATEUR = await _context.UTILISATEUR
                .FirstOrDefaultAsync(m => m.UTILISATEURID == id);
            if (uTILISATEUR == null)
            {
                return NotFound();
            }

            return View(uTILISATEUR);
        }

        // POST: UTILISATEURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uTILISATEUR = await _context.UTILISATEUR.FindAsync(id);
            _context.UTILISATEUR.Remove(uTILISATEUR);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UTILISATEURExists(int id)
        {
            return _context.UTILISATEUR.Any(e => e.UTILISATEURID == id);
        }
    }
}
