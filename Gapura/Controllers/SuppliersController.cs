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
    public class SuppliersController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /Suppliers/

        public ActionResult Index()
        {
            return View(dbConn.Suppliers.ToList());
        }

        ///////////////-------------- Load Data by JQuery Fir 26102016 -----------------/////////////
        public ActionResult LoadData()
        {
            //using (YSIDGAEntitiesConn dc = new YSIDGAEntitiesConn())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                dbConn.Configuration.LazyLoadingEnabled = false;
                //var data = dbConn.Suppliers.OrderBy(s => s.CompanyName).ToList();             //default Way

                //var data = from s in dbConn.Suppliers                                             //Using LinQ
                //           join ca in dbConn.Categories on s.CategoryID equals ca.CategoryID
                //           orderby s.CompanyName
                //           select new { s.SupplierID, s.SupplierCode, ca.CategoryName, s.CompanyName, s.Address, s.City, s.Region, 
                //                        s.ContactName, s.Phone, s.CellPhone, s.Npwp, s.TermOfPayment };

                var data = dbConn.SPR_Suppliers().ToList();                                 //Using SP
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        ///////////////-----------End Load Data by JQuery Fir 26102016 -----------------/////////////

        //
        // GET: /Suppliers/Details/5

        public ActionResult Details(int id = 0)
        {
            Supplier supplier = dbConn.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // GET: /Suppliers/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName");
            ViewBag.TermID = new SelectList(dbConn.TermOfPays, "TermID", "TermDays");
            return View();
        }

        //
        // POST: /Suppliers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                dbConn.Suppliers.Add(supplier);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName", supplier.CategoryID);
            ViewBag.TermID = new SelectList(dbConn.TermOfPays, "TermID", "TermDays", supplier.TermID);
            return View(supplier);
        }

        //
        // GET: /Suppliers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Supplier supplier = dbConn.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName", supplier.CategoryID);
            ViewBag.TermID = new SelectList(dbConn.TermOfPays, "TermID", "TermDays", supplier.TermID);
            return View(supplier);
        }

        //
        // POST: /Suppliers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(supplier).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName", supplier.CategoryID);
            ViewBag.TermID = new SelectList(dbConn.TermOfPays, "TermID", "TermDays", supplier.TermID);
            return View(supplier);
        }

        //
        // GET: /Suppliers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Supplier supplier = dbConn.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // POST: /Suppliers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = dbConn.Suppliers.Find(id);
            dbConn.Suppliers.Remove(supplier);
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