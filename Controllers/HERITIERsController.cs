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
    public class HERITIERsController : Controller
    {
        private bdheritageEntities db = new bdheritageEntities();

        // GET: HERITIERs
        public ActionResult Index()
        {
            return View(db.HERITIER.ToList());
        }

        // GET: HERITIERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HERITIER hERITIER = db.HERITIER.Find(id);
            if (hERITIER == null)
            {
                return HttpNotFound();
            }
            return View(hERITIER);
        }

        // GET: HERITIERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HERITIERs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOMENCLATUREID,DESCRIPTION,CODE,ILLLUSTRATION")] HERITIER hERITIER)
        {
            if (ModelState.IsValid)
            {
                db.HERITIER.Add(hERITIER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hERITIER);
        }

        // GET: HERITIERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HERITIER hERITIER = db.HERITIER.Find(id);
            if (hERITIER == null)
            {
                return HttpNotFound();
            }
            return View(hERITIER);
        }

        // POST: HERITIERs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NOMENCLATUREID,DESCRIPTION,CODE,ILLLUSTRATION")] HERITIER hERITIER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hERITIER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hERITIER);
        }

        // GET: HERITIERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HERITIER hERITIER = db.HERITIER.Find(id);
            if (hERITIER == null)
            {
                return HttpNotFound();
            }
            return View(hERITIER);
        }

        // POST: HERITIERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HERITIER hERITIER = db.HERITIER.Find(id);
            db.HERITIER.Remove(hERITIER);
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
