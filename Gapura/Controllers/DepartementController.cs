using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gapura.Models;

namespace Gapura.Controllers
{
    public class DepartementController : Controller
    {
        private YSIDGAEntitiesConn db = new YSIDGAEntitiesConn();

        //
        // GET: /Departement/

        public ActionResult Index()
        {
            var departements = db.Departements.Include(d => d.Division);
            return View(departements.ToList());
        }

        //
        // GET: /Departement/Details/5

        public ActionResult Details(int id = 0)
        {
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        //
        // GET: /Departement/Create

        public ActionResult Create()
        {
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "DivisionName");
            return View();
        }

        //
        // POST: /Departement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departement departement)
        {
            if (ModelState.IsValid)
            {
                db.Departements.Add(departement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "DivisionName", departement.DivisionID);
            return View(departement);
        }

        //
        // GET: /Departement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "DivisionName", departement.DivisionID);
            return View(departement);
        }

        //
        // POST: /Departement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departement departement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "DivisionName", departement.DivisionID);
            return View(departement);
        }

        //
        // GET: /Departement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }
            return View(departement);
        }

        //
        // POST: /Departement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departement departement = db.Departements.Find(id);
            db.Departements.Remove(departement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}