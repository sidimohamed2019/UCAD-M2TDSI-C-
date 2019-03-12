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
    public class UTILISATEURsController : Controller
    {
        private bdheritageEntities db = new bdheritageEntities();

        // GET: UTILISATEURs
        public ActionResult Index()
        {
            return View(db.UTILISATEUR.ToList());
        }

        // GET: UTILISATEURs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTILISATEUR uTILISATEUR = db.UTILISATEUR.Find(id);
            if (uTILISATEUR == null)
            {
                return HttpNotFound();
            }
            return View(uTILISATEUR);
        }

        // GET: UTILISATEURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UTILISATEURs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UTILISATEURID,UTI_UTILISATEURID,DESIGNATION,EMAIL,TYPEUTILISATEUR")] UTILISATEUR uTILISATEUR)
        {
            if (ModelState.IsValid)
            {
                db.UTILISATEUR.Add(uTILISATEUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uTILISATEUR);
        }

        // GET: UTILISATEURs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTILISATEUR uTILISATEUR = db.UTILISATEUR.Find(id);
            if (uTILISATEUR == null)
            {
                return HttpNotFound();
            }
            return View(uTILISATEUR);
        }

        // POST: UTILISATEURs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UTILISATEURID,UTI_UTILISATEURID,DESIGNATION,EMAIL,TYPEUTILISATEUR")] UTILISATEUR uTILISATEUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uTILISATEUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uTILISATEUR);
        }

        // GET: UTILISATEURs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UTILISATEUR uTILISATEUR = db.UTILISATEUR.Find(id);
            if (uTILISATEUR == null)
            {
                return HttpNotFound();
            }
            return View(uTILISATEUR);
        }

        // POST: UTILISATEURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UTILISATEUR uTILISATEUR = db.UTILISATEUR.Find(id);
            db.UTILISATEUR.Remove(uTILISATEUR);
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
