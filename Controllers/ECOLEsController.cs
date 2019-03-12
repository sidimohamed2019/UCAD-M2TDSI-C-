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
    public class ECOLEsController : Controller
    {
        private bdheritageEntities db = new bdheritageEntities();

        // GET: ECOLEs
        public ActionResult Index()
        {
            var eCOLE = db.ECOLE.Include(e => e.REGLE).Include(e => e.HERITAGE);
            return View(eCOLE.ToList());
        }

        // GET: ECOLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECOLE eCOLE = db.ECOLE.Find(id);
            if (eCOLE == null)
            {
                return HttpNotFound();
            }
            return View(eCOLE);
        }

        // GET: ECOLEs/Create
        public ActionResult Create()
        {
            ViewBag.REGLEID = new SelectList(db.REGLE, "REGLEID", "DESCRIPTION");
            ViewBag.HERITAGEID = new SelectList(db.HERITAGE, "HERITAGEID", "DESCRIPTION");
            return View();
        }

        // POST: ECOLEs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ECOLEID,HERITAGEID,REGLEID,NOM,DESCRIPTION")] ECOLE eCOLE)
        {
            if (ModelState.IsValid)
            {
                db.ECOLE.Add(eCOLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.REGLEID = new SelectList(db.REGLE, "REGLEID", "DESCRIPTION", eCOLE.REGLEID);
            ViewBag.HERITAGEID = new SelectList(db.HERITAGE, "HERITAGEID", "DESCRIPTION", eCOLE.HERITAGEID);
            return View(eCOLE);
        }

        // GET: ECOLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECOLE eCOLE = db.ECOLE.Find(id);
            if (eCOLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.REGLEID = new SelectList(db.REGLE, "REGLEID", "DESCRIPTION", eCOLE.REGLEID);
            ViewBag.HERITAGEID = new SelectList(db.HERITAGE, "HERITAGEID", "DESCRIPTION", eCOLE.HERITAGEID);
            return View(eCOLE);
        }

        // POST: ECOLEs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ECOLEID,HERITAGEID,REGLEID,NOM,DESCRIPTION")] ECOLE eCOLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eCOLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.REGLEID = new SelectList(db.REGLE, "REGLEID", "DESCRIPTION", eCOLE.REGLEID);
            ViewBag.HERITAGEID = new SelectList(db.HERITAGE, "HERITAGEID", "DESCRIPTION", eCOLE.HERITAGEID);
            return View(eCOLE);
        }

        // GET: ECOLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECOLE eCOLE = db.ECOLE.Find(id);
            if (eCOLE == null)
            {
                return HttpNotFound();
            }
            return View(eCOLE);
        }

        // POST: ECOLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ECOLE eCOLE = db.ECOLE.Find(id);
            db.ECOLE.Remove(eCOLE);
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
