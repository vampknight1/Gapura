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
    public class ReleaseDetailController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /ReleaseDetail/

        public ActionResult Index()
        {
            return View(dbConn.ReleaseDetails.ToList());
        }

        //
        // GET: /ReleaseDetail/Details/5

        public ActionResult Details(int id = 0)
        {
            ReleaseDetail releasedetail = dbConn.ReleaseDetails.Find(id);
            if (releasedetail == null)
            {
                return HttpNotFound();
            }
            return View(releasedetail);
        }

        //
        // GET: /ReleaseDetail/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ReleaseDetail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReleaseDetail releasedetail)
        {
            if (ModelState.IsValid)
            {
                dbConn.ReleaseDetails.Add(releasedetail);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(releasedetail);
        }

        //
        // GET: /ReleaseDetail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ReleaseDetail releasedetail = dbConn.ReleaseDetails.Find(id);
            if (releasedetail == null)
            {
                return HttpNotFound();
            }
            return View(releasedetail);
        }

        //
        // POST: /ReleaseDetail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReleaseDetail releasedetail)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(releasedetail).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(releasedetail);
        }

        //
        // GET: /ReleaseDetail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ReleaseDetail releasedetail = dbConn.ReleaseDetails.Find(id);
            if (releasedetail == null)
            {
                return HttpNotFound();
            }
            return View(releasedetail);
        }

        //
        // POST: /ReleaseDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReleaseDetail releasedetail = dbConn.ReleaseDetails.Find(id);
            dbConn.ReleaseDetails.Remove(releasedetail);
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