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
    public class REGLEsController : Controller
    {
        private bdheritageEntities db = new bdheritageEntities();

        // GET: REGLEs
        public ActionResult Index()
        {
            var rEGLE = db.REGLE.Include(r => r.SOURCE);
            return View(rEGLE.ToList());
        }

        // GET: REGLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGLE rEGLE = db.REGLE.Find(id);
            if (rEGLE == null)
            {
                return HttpNotFound();
            }
            return View(rEGLE);
        }

        // GET: REGLEs/Create
        public ActionResult Create()
        {
            ViewBag.SOURCEID = new SelectList(db.SOURCE, "SOURCEID", "DESIGNATION");
            return View();
        }

        // POST: REGLEs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REGLEID,SOURCEID,DESCRIPTION,ECOLES,COMMENTAIRE")] REGLE rEGLE)
        {
            if (ModelState.IsValid)
            {
                db.REGLE.Add(rEGLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SOURCEID = new SelectList(db.SOURCE, "SOURCEID", "DESIGNATION", rEGLE.SOURCEID);
            return View(rEGLE);
        }

        // GET: REGLEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGLE rEGLE = db.REGLE.Find(id);
            if (rEGLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.SOURCEID = new SelectList(db.SOURCE, "SOURCEID", "DESIGNATION", rEGLE.SOURCEID);
            return View(rEGLE);
        }

        // POST: REGLEs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REGLEID,SOURCEID,DESCRIPTION,ECOLES,COMMENTAIRE")] REGLE rEGLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SOURCEID = new SelectList(db.SOURCE, "SOURCEID", "DESIGNATION", rEGLE.SOURCEID);
            return View(rEGLE);
        }

        // GET: REGLEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGLE rEGLE = db.REGLE.Find(id);
            if (rEGLE == null)
            {
                return HttpNotFound();
            }
            return View(rEGLE);
        }

        // POST: REGLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REGLE rEGLE = db.REGLE.Find(id);
            db.REGLE.Remove(rEGLE);
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
