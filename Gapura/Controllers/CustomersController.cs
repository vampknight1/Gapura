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
    public class CustomersController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /Customers/

        public ActionResult Index()
        {
            return View(dbConn.Customers.ToList());
        }

        ///////////////-------------- Load Data by JQuery Fir 26102016 -----------------/////////////
        public ActionResult LoadData()
        {
            //using (YSIDGAEntitiesConn dc = new YSIDGAEntitiesConn())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                dbConn.Configuration.LazyLoadingEnabled = false;
                //var data = dbConn.Customers.OrderBy(c => c.CompanyName).ToList();
                //var data = from cu in dbConn.Customers
                //           orderby cu.CompanyName
                //           select new { cu.DepartemenID, cu.CompanyName, cu.ContactName, cu.ContactTitle, cu.Address, cu.Phone, cu.Fax };

                var data = dbConn.SPR_Customers().ToList();

                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        ///////////////-----------End Load Data by JQuery Fir 26102016 -----------------/////////////

        //
        // GET: /Customers/Details/5

        public ActionResult Details(string id = null)
        {
            Customer customer = dbConn.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // GET: /Customers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                dbConn.Customers.Add(customer);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //
        // GET: /Customers/Edit/5

        public ActionResult Edit(string id = null)
        {
            Customer customer = dbConn.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(customer).State = EntityState.Modified;
                dbConn.SaveChanges();
                //return RedirectToAction("Index");
                ViewBag.ResultMessage = "Data has been changed.. ";
                //: message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                //: message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                //: "";
            }
            return View(customer);
        }

        //
        // GET: /Customers/Delete/5

        public ActionResult Delete(string id = null)
        {
            Customer customer = dbConn.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = dbConn.Customers.Find(id);
            dbConn.Customers.Remove(customer);
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