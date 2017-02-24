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
    public class AssetsTypesController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /AssetsTypes/

        public ActionResult Index()
        {
            return View(dbConn.MasterAssetsTypes.ToList());
        }

        //
        // GET: /AssetsTypes/Details/5

        public ActionResult Details(short id = 0)
        {
            MasterAssetsType masterassetstype = dbConn.MasterAssetsTypes.Find(id);
            if (masterassetstype == null)
            {
                return HttpNotFound();
            }
            return View(masterassetstype);
        }

        //
        // GET: /AssetsTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AssetsTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterAssetsType masterassetstype)
        {
            if (ModelState.IsValid)
            {
                dbConn.MasterAssetsTypes.Add(masterassetstype);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterassetstype);
        }

        //
        // GET: /AssetsTypes/Edit/5

        public ActionResult Edit(short id = 0)
        {
            MasterAssetsType masterassetstype = dbConn.MasterAssetsTypes.Find(id);
            if (masterassetstype == null)
            {
                return HttpNotFound();
            }
            return View(masterassetstype);
        }

        //
        // POST: /AssetsTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterAssetsType masterassetstype)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(masterassetstype).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterassetstype);
        }

        //
        // GET: /AssetsTypes/Delete/5

        public ActionResult Delete(short id = 0)
        {
            MasterAssetsType masterassetstype = dbConn.MasterAssetsTypes.Find(id);
            if (masterassetstype == null)
            {
                return HttpNotFound();
            }
            return View(masterassetstype);
        }

        //
        // POST: /AssetsTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MasterAssetsType masterassetstype = dbConn.MasterAssetsTypes.Find(id);
            dbConn.MasterAssetsTypes.Remove(masterassetstype);
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