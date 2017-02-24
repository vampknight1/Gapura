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
    public class PeriodsController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        public JsonResult IsPeriodNameAvailable(string PeriodName)
        {
            return Json(!dbConn.MasterPeriods.Any(PerName => PerName.PeriodName == PeriodName), JsonRequestBehavior.AllowGet);   
        }

        //
        // GET: /Periods/

        public ActionResult Index()
        {
            return View(dbConn.MasterPeriods.ToList());
        }

        //
        // GET: /Periods/Details/5

        public ActionResult Details(int id = 0)
        {
            MasterPeriod masterperiod = dbConn.MasterPeriods.Find(id);
            if (masterperiod == null)
            {
                return HttpNotFound();
            }
            return View(masterperiod);
        }

        //
        // GET: /Periods/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Periods/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPeriod masterperiod)
        {
            if (ModelState.IsValid)
            {
                dbConn.MasterPeriods.Add(masterperiod);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterperiod);
        }

        //
        // GET: /Periods/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MasterPeriod masterperiod = dbConn.MasterPeriods.Find(id);
            if (masterperiod == null)
            {
                return HttpNotFound();
            }
            return View(masterperiod);
        }

        //
        // POST: /Periods/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterPeriod masterperiod)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(masterperiod).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterperiod);
        }

        //
        // GET: /Periods/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MasterPeriod masterperiod = dbConn.MasterPeriods.Find(id);
            if (masterperiod == null)
            {
                return HttpNotFound();
            }
            return View(masterperiod);
        }

        //
        // POST: /Periods/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterPeriod masterperiod = dbConn.MasterPeriods.Find(id);
            dbConn.MasterPeriods.Remove(masterperiod);
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