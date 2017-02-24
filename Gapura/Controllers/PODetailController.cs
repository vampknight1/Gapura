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
    public class PODetailController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /PODetail/

        public ActionResult Index()
        {
            var podetails = dbConn.PODetails.Include(p => p.POHeader);
            return View(podetails.ToList());
        }

        //
        // GET: /PODetail/Details/5

        public ActionResult Details(int id = 0)
        {
            PODetail podetail = dbConn.PODetails.Find(id);
            if (podetail == null)
            {
                return HttpNotFound();
            }
            return View(podetail);
        }

        //
        // GET: /PODetail/Create

        public ActionResult Create()
        {
            ViewBag.POID = new SelectList(dbConn.POHeaders, "POID", "RequestID");
            return View();
        }

        //
        // POST: /PODetail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PODetail podetail)
        {
            if (ModelState.IsValid)
            {
                dbConn.PODetails.Add(podetail);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.POID = new SelectList(dbConn.POHeaders, "POID", "RequestID", podetail.POID);
            return View(podetail);
        }

        //
        // GET: /PODetail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PODetail podetail = dbConn.PODetails.Find(id);
            if (podetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.POID = new SelectList(dbConn.POHeaders, "POID", "RequestID", podetail.POID);
            return View(podetail);
        }

        //
        // POST: /PODetail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PODetail podetail)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(podetail).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.POID = new SelectList(dbConn.POHeaders, "POID", "RequestID", podetail.POID);
            return View(podetail);
        }

        //
        // GET: /PODetail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PODetail podetail = dbConn.PODetails.Find(id);
            if (podetail == null)
            {
                return HttpNotFound();
            }
            return View(podetail);
        }

        //
        // POST: /PODetail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PODetail podetail = dbConn.PODetails.Find(id);
            dbConn.PODetails.Remove(podetail);
            dbConn.SaveChanges();
            //return RedirectToAction("Index");
            //return Redirect(Request.UrlReferrer.ToString());
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            dbConn.Dispose();
            base.Dispose(disposing);
        }
    }
}