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
    public class MasterTitleController : Controller
    {
        private YSIDGAEntitiesConn _dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /MasterTitle/

        public ActionResult Index()
        {
            return View(_dbConn.MasterTitles.ToList());
        }

        //
        // GET: /MasterTitle/Details/5

        public ActionResult Details(int id = 0)
        {
            MasterTitle mastertitle = _dbConn.MasterTitles.Find(id);
            if (mastertitle == null)
            {
                return HttpNotFound();
            }
            return View(mastertitle);
        }

        //
        // GET: /MasterTitle/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MasterTitle/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterTitle mastertitle)
        {
            if (ModelState.IsValid)
            {
                _dbConn.MasterTitles.Add(mastertitle);
                _dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mastertitle);
        }

        //
        // GET: /MasterTitle/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MasterTitle mastertitle = _dbConn.MasterTitles.Find(id);
            if (mastertitle == null)
            {
                return HttpNotFound();
            }
            return View(mastertitle);
        }

        //
        // POST: /MasterTitle/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterTitle mastertitle)
        {
            if (ModelState.IsValid)
            {
                _dbConn.Entry(mastertitle).State = EntityState.Modified;
                _dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mastertitle);
        }

        //
        // GET: /MasterTitle/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MasterTitle mastertitle = _dbConn.MasterTitles.Find(id);
            if (mastertitle == null)
            {
                return HttpNotFound();
            }
            return View(mastertitle);
        }

        //
        // POST: /MasterTitle/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterTitle mastertitle = _dbConn.MasterTitles.Find(id);
            _dbConn.MasterTitles.Remove(mastertitle);
            _dbConn.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _dbConn.Dispose();
            base.Dispose(disposing);
        }
    }
}