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
    public class BIENSController : Controller
    {
        private bdheritageEntities db = new bdheritageEntities();

        // GET: BIENS
        public ActionResult Index()
        {
            var bIENS = db.BIENS.Include(b => b.HERITAGE);
            return View(bIENS.ToList());
        }

        // GET: BIENS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENS bIENS = db.BIENS.Find(id);
            if (bIENS == null)
            {
                return HttpNotFound();
            }
            return View(bIENS);
        }

        // GET: BIENS/Create
        public ActionResult Create()
        {
            ViewBag.HERITAGEID = new SelectList(db.HERITAGE, "HERITAGEID", "DESCRIPTION");
            return View();
        }

        // POST: BIENS/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BIENID,HERITAGEID,DESCRIPTION,EVALUATEUR,AFFECTATION")] BIENS bIENS)
        {
            if (ModelState.IsValid)
            {
                db.BIENS.Add(bIENS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HERITAGEID = new SelectList(db.HERITAGE, "HERITAGEID", "DESCRIPTION", bIENS.HERITAGEID);
            return View(bIENS);
        }

        // GET: BIENS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENS bIENS = db.BIENS.Find(id);
            if (bIENS == null)
            {
                return HttpNotFound();
            }
            ViewBag.HERITAGEID = new SelectList(db.HERITAGE, "HERITAGEID", "DESCRIPTION", bIENS.HERITAGEID);
            return View(bIENS);
        }

        // POST: BIENS/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BIENID,HERITAGEID,DESCRIPTION,EVALUATEUR,AFFECTATION")] BIENS bIENS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bIENS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HERITAGEID = new SelectList(db.HERITAGE, "HERITAGEID", "DESCRIPTION", bIENS.HERITAGEID);
            return View(bIENS);
        }

        // GET: BIENS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENS bIENS = db.BIENS.Find(id);
            if (bIENS == null)
            {
                return HttpNotFound();
            }
            return View(bIENS);
        }

        // POST: BIENS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BIENS bIENS = db.BIENS.Find(id);
            db.BIENS.Remove(bIENS);
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
