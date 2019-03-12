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
    public class SOURCEsController : Controller
    {
        private bdheritageEntities db = new bdheritageEntities();

        // GET: SOURCEs
        public ActionResult Index()
        {
            return View(db.SOURCE.ToList());
        }

        // GET: SOURCEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOURCE sOURCE = db.SOURCE.Find(id);
            if (sOURCE == null)
            {
                return HttpNotFound();
            }
            return View(sOURCE);
        }

        // GET: SOURCEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SOURCEs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SOURCEID,DESIGNATION,HIERARCHIEID,COMMENTAIRE")] SOURCE sOURCE)
        {
            if (ModelState.IsValid)
            {
                db.SOURCE.Add(sOURCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sOURCE);
        }

        // GET: SOURCEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOURCE sOURCE = db.SOURCE.Find(id);
            if (sOURCE == null)
            {
                return HttpNotFound();
            }
            return View(sOURCE);
        }

        // POST: SOURCEs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SOURCEID,DESIGNATION,HIERARCHIEID,COMMENTAIRE")] SOURCE sOURCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOURCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sOURCE);
        }

        // GET: SOURCEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOURCE sOURCE = db.SOURCE.Find(id);
            if (sOURCE == null)
            {
                return HttpNotFound();
            }
            return View(sOURCE);
        }

        // POST: SOURCEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOURCE sOURCE = db.SOURCE.Find(id);
            db.SOURCE.Remove(sOURCE);
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
