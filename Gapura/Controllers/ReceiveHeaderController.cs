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
    public class ReceiveHeaderController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /ReceiveHeader/

        public ActionResult Index()
        {
            return View(dbConn.ReceiveHeaders.ToList());
        }

        //
        // GET: /ReceiveHeader/Details/5

        public ActionResult Details(int id = 0)
        {
            ReceiveHeader receiveheader = dbConn.ReceiveHeaders.Find(id);
            if (receiveheader == null)
            {
                return HttpNotFound();
            }
            return View(receiveheader);
        }

        //
        // GET: /ReceiveHeader/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ReceiveHeader/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReceiveHeader receiveheader)
        {
            if (ModelState.IsValid)
            {
                dbConn.ReceiveHeaders.Add(receiveheader);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receiveheader);
        }

        //
        // GET: /ReceiveHeader/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ReceiveHeader receiveheader = dbConn.ReceiveHeaders.Find(id);
            if (receiveheader == null)
            {
                return HttpNotFound();
            }
            return View(receiveheader);
        }

        //
        // POST: /ReceiveHeader/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReceiveHeader receiveheader)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(receiveheader).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receiveheader);
        }

        //
        // GET: /ReceiveHeader/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ReceiveHeader receiveheader = dbConn.ReceiveHeaders.Find(id);
            if (receiveheader == null)
            {
                return HttpNotFound();
            }
            return View(receiveheader);
        }

        //
        // POST: /ReceiveHeader/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiveHeader receiveheader = dbConn.ReceiveHeaders.Find(id);
            dbConn.ReceiveHeaders.Remove(receiveheader);
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