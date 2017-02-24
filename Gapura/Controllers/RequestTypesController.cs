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
    public class RequestTypesController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /RequestTypes/

        public ActionResult Index()
        {
            return View(dbConn.MasterRequestTypes.ToList());
        }

        //
        // GET: /RequestTypes/Details/5

        public ActionResult Details(short id = 0)
        {
            MasterRequestType masterrequesttype = dbConn.MasterRequestTypes.Find(id);
            if (masterrequesttype == null)
            {
                return HttpNotFound();
            }
            return View(masterrequesttype);
        }

        //
        // GET: /RequestTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RequestTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterRequestType masterrequesttype)
        {
            if (ModelState.IsValid)
            {
                dbConn.MasterRequestTypes.Add(masterrequesttype);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterrequesttype);
        }

        //
        // GET: /RequestTypes/Edit/5

        public ActionResult Edit(short id = 0)
        {
            MasterRequestType masterrequesttype = dbConn.MasterRequestTypes.Find(id);
            if (masterrequesttype == null)
            {
                return HttpNotFound();
            }
            return View(masterrequesttype);
        }

        //
        // POST: /RequestTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterRequestType masterrequesttype)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(masterrequesttype).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterrequesttype);
        }

        //
        // GET: /RequestTypes/Delete/5

        public ActionResult Delete(short id = 0)
        {
            MasterRequestType masterrequesttype = dbConn.MasterRequestTypes.Find(id);
            if (masterrequesttype == null)
            {
                return HttpNotFound();
            }
            return View(masterrequesttype);
        }

        //
        // POST: /RequestTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MasterRequestType masterrequesttype = dbConn.MasterRequestTypes.Find(id);
            dbConn.MasterRequestTypes.Remove(masterrequesttype);
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