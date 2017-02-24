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
    public class CurrenciesController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /Currencies/

        public ActionResult Index()
        {
            return View(dbConn.MasterCurrencies.ToList());
        }

        //
        // GET: /Currencies/Details/5

        public ActionResult Details(short id = 0)
        {
            MasterCurrency mastercurrency = dbConn.MasterCurrencies.Find(id);
            if (mastercurrency == null)
            {
                return HttpNotFound();
            }
            return View(mastercurrency);
        }

        //
        // GET: /Currencies/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Currencies/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCurrency mastercurrency)
        {
            if (ModelState.IsValid)
            {
                dbConn.MasterCurrencies.Add(mastercurrency);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mastercurrency);
        }

        //
        // GET: /Currencies/Edit/5

        public ActionResult Edit(short id = 0)
        {
            MasterCurrency mastercurrency = dbConn.MasterCurrencies.Find(id);
            if (mastercurrency == null)
            {
                return HttpNotFound();
            }
            return View(mastercurrency);
        }

        //
        // POST: /Currencies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterCurrency mastercurrency)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(mastercurrency).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mastercurrency);
        }

        //
        // GET: /Currencies/Delete/5

        public ActionResult Delete(short id = 0)
        {
            MasterCurrency mastercurrency = dbConn.MasterCurrencies.Find(id);
            if (mastercurrency == null)
            {
                return HttpNotFound();
            }
            return View(mastercurrency);
        }

        //
        // POST: /Currencies/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            MasterCurrency mastercurrency = dbConn.MasterCurrencies.Find(id);
            dbConn.MasterCurrencies.Remove(mastercurrency);
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