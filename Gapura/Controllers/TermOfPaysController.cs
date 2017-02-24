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
    public class TermOfPaysController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /TermOfPays/

        public ActionResult Index()
        {
            return View(dbConn.TermOfPays.ToList());
        }

        //
        // GET: /TermOfPays/Details/5

        public ActionResult Details(short id = 0)
        {
            TermOfPay termofpay = dbConn.TermOfPays.Find(id);
            if (termofpay == null)
            {
                return HttpNotFound();
            }
            return View(termofpay);
        }

        //
        // GET: /TermOfPays/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TermOfPays/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TermOfPay termofpay)
        {
            if (ModelState.IsValid)
            {
                dbConn.TermOfPays.Add(termofpay);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(termofpay);
        }

        //
        // GET: /TermOfPays/Edit/5

        public ActionResult Edit(short id = 0)
        {
            TermOfPay termofpay = dbConn.TermOfPays.Find(id);
            if (termofpay == null)
            {
                return HttpNotFound();
            }
            return View(termofpay);
        }

        //
        // POST: /TermOfPays/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TermOfPay termofpay)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(termofpay).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(termofpay);
        }

        //
        // GET: /TermOfPays/Delete/5

        public ActionResult Delete(short id = 0)
        {
            TermOfPay termofpay = dbConn.TermOfPays.Find(id);
            if (termofpay == null)
            {
                return HttpNotFound();
            }
            return View(termofpay);
        }

        //
        // POST: /TermOfPays/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            TermOfPay termofpay = dbConn.TermOfPays.Find(id);
            dbConn.TermOfPays.Remove(termofpay);
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