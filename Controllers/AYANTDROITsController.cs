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
    public class AYANTDROITsController : Controller
    {
        private bdheritageEntities db = new bdheritageEntities();

        // GET: AYANTDROITs
        public ActionResult Index()
        {
            var aYANTDROIT = db.AYANTDROIT.Include(a => a.UTILISATEUR).Include(a => a.HERITIER);
            return View(aYANTDROIT.ToList());
        }

        // GET: AYANTDROITs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AYANTDROIT aYANTDROIT = db.AYANTDROIT.Find(id);
            if (aYANTDROIT == null)
            {
                return HttpNotFound();
            }
            return View(aYANTDROIT);
        }

        // GET: AYANTDROITs/Create
        public ActionResult Create()
        {
            ViewBag.UTILISATEURID = new SelectList(db.UTILISATEUR, "UTILISATEURID", "DESIGNATION");
            ViewBag.NOMENCLATUREID = new SelectList(db.HERITIER, "NOMENCLATUREID", "DESCRIPTION");
            return View();
        }

        // POST: AYANTDROITs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ADRID,NOMENCLATUREID,UTILISATEURID,DESIGNATION,IMAGEADR,DESCRIPTION,DATECREATION,TYPEHERITIER,NOM,PRENOM,DATENAISSANCE,SEXE")] AYANTDROIT aYANTDROIT)
        {
            if (ModelState.IsValid)
            {
                db.AYANTDROIT.Add(aYANTDROIT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UTILISATEURID = new SelectList(db.UTILISATEUR, "UTILISATEURID", "DESIGNATION", aYANTDROIT.UTILISATEURID);
            ViewBag.NOMENCLATUREID = new SelectList(db.HERITIER, "NOMENCLATUREID", "DESCRIPTION", aYANTDROIT.NOMENCLATUREID);
            return View(aYANTDROIT);
        }

        // GET: AYANTDROITs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AYANTDROIT aYANTDROIT = db.AYANTDROIT.Find(id);
            if (aYANTDROIT == null)
            {
                return HttpNotFound();
            }
            ViewBag.UTILISATEURID = new SelectList(db.UTILISATEUR, "UTILISATEURID", "DESIGNATION", aYANTDROIT.UTILISATEURID);
            ViewBag.NOMENCLATUREID = new SelectList(db.HERITIER, "NOMENCLATUREID", "DESCRIPTION", aYANTDROIT.NOMENCLATUREID);
            return View(aYANTDROIT);
        }

        // POST: AYANTDROITs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ADRID,NOMENCLATUREID,UTILISATEURID,DESIGNATION,IMAGEADR,DESCRIPTION,DATECREATION,TYPEHERITIER,NOM,PRENOM,DATENAISSANCE,SEXE")] AYANTDROIT aYANTDROIT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aYANTDROIT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UTILISATEURID = new SelectList(db.UTILISATEUR, "UTILISATEURID", "DESIGNATION", aYANTDROIT.UTILISATEURID);
            ViewBag.NOMENCLATUREID = new SelectList(db.HERITIER, "NOMENCLATUREID", "DESCRIPTION", aYANTDROIT.NOMENCLATUREID);
            return View(aYANTDROIT);
        }

        // GET: AYANTDROITs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AYANTDROIT aYANTDROIT = db.AYANTDROIT.Find(id);
            if (aYANTDROIT == null)
            {
                return HttpNotFound();
            }
            return View(aYANTDROIT);
        }

        // POST: AYANTDROITs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AYANTDROIT aYANTDROIT = db.AYANTDROIT.Find(id);
            db.AYANTDROIT.Remove(aYANTDROIT);
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
