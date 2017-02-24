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
    public class CategoriesController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /Categories/

        public ActionResult Index()
        {
            return View(dbConn.Categories.ToList());
        }

        ///////////////-------------- Load Data by JQuery Fir 26102016 -----------------/////////////
        public ActionResult LoadData()
        {
            //using (YSIDGAEntitiesConn dc = new YSIDGAEntitiesConn())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                dbConn.Configuration.LazyLoadingEnabled = false;
                //var data = dbConn.Categories.OrderBy(p => p.CategoryName).ToList();

                var data = dbConn.SPR_Categories().ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        ///////////////-----------End Load Data by JQuery Fir 26102016 -----------------/////////////

        //
        // GET: /Categories/Details/5

        public ActionResult Details(int id = 0)
        {
            Category Category = dbConn.Categories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            return View(Category);
        }

        //
        // GET: /Categories/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(dbConn.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        //
        // POST: /Categories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category Category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbConn.Categories.Add(Category);
                    dbConn.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
                {
                    ModelState.AddModelError(string.Empty, "Ga bisa disimpan !!");
                }

            //ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName", Category.CategoryID);
            //ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", Category.SupplierID);
            return View(Category);
        }

        //
        // GET: /Categories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category Category = dbConn.Categories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            return View(Category);
        }

        //
        // POST: /Categories/Edit/5

        [HttpPost]
        public ActionResult Edit(Category Category)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(Category).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName", Category.CategoryID);
            //ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", Category.SupplierID);
            return View(Category);
        }

        //
        // GET: /Categories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Category Category = dbConn.Categories.Find(id);
            if (Category == null)
            {
                return HttpNotFound();
            }
            return View(Category);
        }

        //
        // POST: /Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category Category = dbConn.Categories.Find(id);
            dbConn.Categories.Remove(Category);
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