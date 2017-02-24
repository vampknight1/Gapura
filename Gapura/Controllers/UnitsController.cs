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
    public class UnitsController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /Units/

        public ActionResult Index()
        {
            return View(dbConn.MasterUnits.ToList());
        }

        public JsonResult getUnits()
        {
            List<MasterUnit> Units = new List<MasterUnit>();
            using (YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn())
            {
                Units = dbConn.MasterUnits.OrderBy(u => u.UnitName).ToList();
            }
            return new JsonResult { Data = Units, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //
        // GET: /Units/Details/5

        public ActionResult Details(int id = 0)
        {
            MasterUnit masterunit = dbConn.MasterUnits.Find(id);
            if (masterunit == null)
            {
                return HttpNotFound();
            }
            return View(masterunit);
        }

        //
        // GET: /Units/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Units/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterUnit masterunit)
        {
            if (ModelState.IsValid)
            {
                dbConn.MasterUnits.Add(masterunit);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterunit);
        }

        //
        // GET: /Units/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MasterUnit masterunit = dbConn.MasterUnits.Find(id);
            if (masterunit == null)
            {
                return HttpNotFound();
            }
            return View(masterunit);
        }

        //
        // POST: /Units/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterUnit masterunit)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(masterunit).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterunit);
        }

        //
        // GET: /Units/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MasterUnit masterunit = dbConn.MasterUnits.Find(id);
            if (masterunit == null)
            {
                return HttpNotFound();
            }
            return View(masterunit);
        }

        //
        // POST: /Units/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterUnit masterunit = dbConn.MasterUnits.Find(id);
            dbConn.MasterUnits.Remove(masterunit);
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