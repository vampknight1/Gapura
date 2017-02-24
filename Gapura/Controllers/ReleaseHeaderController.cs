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
    public class ReleaseHeaderController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /ReleaseHeader/

        public ActionResult Index()
        {
            return View(dbConn.ReleaseHeaders.ToList());
        }

        //
        // GET: /ReleaseHeader/Details/5

        public ActionResult Details(int id = 0)
        {
            ReleaseHeader releaseheader = dbConn.ReleaseHeaders.Find(id);
            if (releaseheader == null)
            {
                return HttpNotFound();
            }
            return View(releaseheader);
        }

        //
        // GET: /ReleaseHeader/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ReleaseHeader/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReleaseHeader releaseheader)
        {
            if (ModelState.IsValid)
            {
                dbConn.ReleaseHeaders.Add(releaseheader);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(releaseheader);
        }

        //
        // GET: /ReleaseHeader/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ReleaseHeader releaseheader = dbConn.ReleaseHeaders.Find(id);
            if (releaseheader == null)
            {
                return HttpNotFound();
            }
            return View(releaseheader);
        }

        //
        // POST: /ReleaseHeader/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReleaseHeader releaseheader)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(releaseheader).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(releaseheader);
        }

        //
        // GET: /ReleaseHeader/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ReleaseHeader releaseheader = dbConn.ReleaseHeaders.Find(id);
            if (releaseheader == null)
            {
                return HttpNotFound();
            }
            return View(releaseheader);
        }

        //
        // POST: /ReleaseHeader/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReleaseHeader releaseheader = dbConn.ReleaseHeaders.Find(id);
            dbConn.ReleaseHeaders.Remove(releaseheader);
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