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
    public class MasterOfficeController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /MasterOffice/

        public ActionResult Index()
        {
            return View(dbConn.MasterOffices.ToList());
        }

        //
        // GET: /MasterOffice/Details/5

        public ActionResult Details(int id = 0)
        {
            MasterOffice masteroffice = dbConn.MasterOffices.Find(id);
            if (masteroffice == null)
            {
                return HttpNotFound();
            }
            return View(masteroffice);
        }

        //
        // GET: /MasterOffice/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MasterOffice/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOffice masteroffice)
        {
            if (ModelState.IsValid)
            {
                dbConn.MasterOffices.Add(masteroffice);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masteroffice);
        }

        //
        // GET: /MasterOffice/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MasterOffice masteroffice = dbConn.MasterOffices.Find(id);
            if (masteroffice == null)
            {
                return HttpNotFound();
            }
            return View(masteroffice);
        }

        //
        // POST: /MasterOffice/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterOffice masteroffice)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(masteroffice).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masteroffice);
        }

        //
        // GET: /MasterOffice/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MasterOffice masteroffice = dbConn.MasterOffices.Find(id);
            if (masteroffice == null)
            {
                return HttpNotFound();
            }
            return View(masteroffice);
        }

        //
        // POST: /MasterOffice/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterOffice masteroffice = dbConn.MasterOffices.Find(id);
            dbConn.MasterOffices.Remove(masteroffice);
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