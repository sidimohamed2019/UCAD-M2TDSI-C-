using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HeritagesProjectG6.Models;

namespace HeritagesProjectG6.Controllers
{
    public class HERITAGEsController : Controller
    {
        private bdheritageEntities db = new bdheritageEntities();

        // GET: HERITAGEs
        public ActionResult Index()
        {
            var hERITAGE = db.HERITAGE.Include(h => h.HERITIER);
            return View(hERITAGE.ToList());
        }

        // GET: HERITAGEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HERITAGE hERITAGE = db.HERITAGE.Find(id);
            if (hERITAGE == null)
            {
                return HttpNotFound();
            }
            return View(hERITAGE);
        }

        // GET: HERITAGEs/Create
        public ActionResult Create()
        {
            ViewBag.NOMENCLATUREID = new SelectList(db.HERITIER, "NOMENCLATUREID", "DESCRIPTION");
            return View();
        }

        // POST: HERITAGEs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HERITAGEID,NOMENCLATUREID,DESCRIPTION,DATE_DECES,DATE_HERITAGE,ECOLEID,MONTANT")] HERITAGE hERITAGE)
        {
            if (ModelState.IsValid)
            {
                db.HERITAGE.Add(hERITAGE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NOMENCLATUREID = new SelectList(db.HERITIER, "NOMENCLATUREID", "DESCRIPTION", hERITAGE.NOMENCLATUREID);
            return View(hERITAGE);
        }

        // GET: HERITAGEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HERITAGE hERITAGE = db.HERITAGE.Find(id);
            if (hERITAGE == null)
            {
                return HttpNotFound();
            }
            ViewBag.NOMENCLATUREID = new SelectList(db.HERITIER, "NOMENCLATUREID", "DESCRIPTION", hERITAGE.NOMENCLATUREID);
            return View(hERITAGE);
        }

        // POST: HERITAGEs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HERITAGEID,NOMENCLATUREID,DESCRIPTION,DATE_DECES,DATE_HERITAGE,ECOLEID,MONTANT")] HERITAGE hERITAGE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hERITAGE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NOMENCLATUREID = new SelectList(db.HERITIER, "NOMENCLATUREID", "DESCRIPTION", hERITAGE.NOMENCLATUREID);
            return View(hERITAGE);
        }

        // GET: HERITAGEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HERITAGE hERITAGE = db.HERITAGE.Find(id);
            if (hERITAGE == null)
            {
                return HttpNotFound();
            }
            return View(hERITAGE);
        }

        // POST: HERITAGEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HERITAGE hERITAGE = db.HERITAGE.Find(id);
            db.HERITAGE.Remove(hERITAGE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
