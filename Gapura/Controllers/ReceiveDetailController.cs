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
    public class ReceiveDetailController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /ReceiveDetail/

        public ActionResult Index()
        {
            return View(dbConn.ReceiveDetails.ToList());
        }

        //
        // GET: /ReceiveDetail/Details/5

        public ActionResult Details(int id = 0)
        {
            ReceiveDetail receivedetail = dbConn.ReceiveDetails.Find(id);
            if (receivedetail == null)
            {
                return HttpNotFound();
            }
            return View(receivedetail);
        }

        //
        // GET: /ReceiveDetail/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ReceiveDetail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReceiveDetail receivedetail)
        {
            if (ModelState.IsValid)
            {
                dbConn.ReceiveDetails.Add(receivedetail);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receivedetail);
        }

        //
        // GET: /ReceiveDetail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ReceiveDetail receivedetail = dbConn.ReceiveDetails.Find(id);
            if (receivedetail == null)
            {
                return HttpNotFound();
            }
            return View(receivedetail);
        }

        //
        // POST: /ReceiveDetail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReceiveDetail receivedetail)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(receivedetail).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receivedetail);
        }

        //
        // GET: /ReceiveDetail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ReceiveDetail receivedetail = dbConn.ReceiveDetails.Find(id);
            if (receivedetail == null)
            {
                return HttpNotFound();
            }
            return View(receivedetail);
        }

        //
        // POST: /ReceiveDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiveDetail receivedetail = dbConn.ReceiveDetails.Find(id);
            dbConn.ReceiveDetails.Remove(receivedetail);
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