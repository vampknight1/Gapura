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
    public class TransTypesController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /TransTypes/

        public ActionResult Index()
        {
            return View(dbConn.MasterTransTypes.ToList());
        }

        //
        // GET: /TransTypes/Details/5

        public ActionResult Details(short id = 0)
        {
            MasterTransType mastertranstype = dbConn.MasterTransTypes.Find(id);
            if (mastertranstype == null)
            {
                return HttpNotFound();
            }
            return View(mastertranstype);
        }

        //
        // GET: /TransTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TransTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterTransType mastertranstype)
        {
            if (ModelState.IsValid)
            {
                dbConn.MasterTransTypes.Add(mastertranstype);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mastertranstype);
        }

        //
        // GET: /TransTypes/Edit/5

        public ActionResult Edit(short id = 0)
        {
            MasterTransType mastertranstype = dbConn.MasterTransTypes.Find(id);
            if (mastertranstype == null)
            {
                return HttpNotFound();
            }
            return View(mastertranstype);
        }

        //
        // POST: /TransTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterTransType mastertranstype)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(mastertranstype).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mastertranstype);
        }

        //
        // GET: /TransTypes/Delete/5

        public ActionResult Delete(short id = 0)
        {
            MasterTransType mastertranstype = dbConn.MasterTransTypes.Find(id);
            if (mastertranstype == null)
            {
                return HttpNotFound();
            }
            return View(mastertranstype);
        }

        //
        // POST: /TransTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MasterTransType mastertranstype = dbConn.MasterTransTypes.Find(id);
            dbConn.MasterTransTypes.Remove(mastertranstype);
            dbConn.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            dbConn.Dispose();
            base.Dispose(disposing);
        }
    }
}