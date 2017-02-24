using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gapura.Models;
using Gapura.ViewModel;

namespace Gapura.Controllers
{
    public class ProductsInventoryController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /ProductsInventory/

        public ActionResult Index()
        {
            return View(dbConn.ProductsInventories.ToList());
        }

        ///////////////-------------- Load Data by JQuery Fir 26102016 -----------------/////////////
        public ActionResult LoadData()
        {
            //using (YSIDGAEntitiesConn dc = new YSIDGAEntitiesConn())
            {
                //// dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                dbConn.Configuration.LazyLoadingEnabled = false;
               ////var data = dbConn.Products.OrderBy(p => p.ProductName).ToList();
                //var data = from pi in dbConn.ProductsInventories
                //           join p in dbConn.Products on pi.ProductID equals p.ProductID
                //           join cu in dbConn.Customers on pi.DepartemenID equals cu.DepartemenID
                //           join ca in dbConn.Categories on pi.CategoryID equals ca.CategoryID
                //           orderby p.ProductCode
                //           select new { pi.ProductID, pi.DepartemenID, p.ProductCode, cu.CompanyName, p.ProductName, ca.CategoryName, pi.UnitsInStock, pi.UnitsOnOrder };
                //return Json(new { data = data }, JsonRequestBehavior.AllowGet);

                var data = dbConn.SPR_ProductsInventory().ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        ///////////////-----------End Load Data by JQuery Fir 26102016 -----------------/////////////

        public ActionResult ListProductsInventoryProductVM()
        {
            var data = (from pi in dbConn.ProductsInventories
                           join p in dbConn.Products on pi.ProductID equals p.ProductID
                           join d in dbConn.Departements on pi.DepartemenID equals d.DepartemenID
                           into ThisList
                           orderby p.ProductCode
                           select new
                        {
                            ProductID = p.ProductID,
                            //CompanyName = c.DepartemenID,
                            ProductCode = p.ProductCode,
                            ProductName = p.ProductName,
                            UnitsInStock = pi.UnitsInStock,
                            UnitsOnOrder = pi.UnitsOnOrder
                        }).ToList()
                       .Select(x => new ProductsInventoryProductVM()
                       {
                           ProductID = x.ProductID,
                            //CompanyName = x.CompanyName,
                            ProductCode = x.ProductCode,
                            ProductName = x.ProductName,
                            UnitsInStock = x.UnitsInStock,
                            UnitsOnOrder = x.UnitsOnOrder
                       });
                 
                  return View(data);
        }

        //
        // GET: /ProductsInventory/Details/5

        public ActionResult Details(int ProductID = 0, string DepartemenID = null)
        {
            ProductsInventory productsinventory = dbConn.ProductsInventories.Find(ProductID, DepartemenID);
            if (productsinventory == null)
            {
                return HttpNotFound();
            }
            return View(productsinventory);
        }

        //
        // GET: /ProductsInventory/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProductsInventory/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsInventory productsinventory)
        {
            if (ModelState.IsValid)
            {
                dbConn.ProductsInventories.Add(productsinventory);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productsinventory);
        }

        //
        // GET: /ProductsInventory/Edit/5

        public ActionResult Edit(int ProductID = 0, int DepartemenID = 0)
        {
            ProductsInventory productsinventory = dbConn.ProductsInventories.Find(ProductID, DepartemenID);
            if (productsinventory == null)
            {
                return HttpNotFound();
            }

            // Test Using Class Tuple
            //var ProductInventoryTuple = new Tuple<List<ProductsInventory>, List<Product>>
            //    (dbConn.ProductsInventories.OrderBy(pi => pi.ProductID).ToList(), dbConn.Products.OrderBy(p => p.ProductID).ToList()) { };

            //ViewBag.DepartemenID = new SelectList(dbConn.Customers, "DepartemenID", "CompanyName", productsinventory.DepartemenID);
            ViewBag.DepartemenID = from pi in dbConn.ProductsInventories
                                   join c in dbConn.Departements on pi.DepartemenID equals c.DepartemenID
                                select new
                                {
                                    DepartemenID = pi.DepartemenID,
                                    Departemen = c.DepartemenName
                                };

            //ViewBag.ProductID = new SelectList(dbConn.Products, "ProductID", "ProductName", productsinventory.ProductID);
            ViewBag.ProductID = from pi in dbConn.ProductsInventories
                                join p in dbConn.Products on pi.ProductID equals p.ProductID
                                select new
                                {
                                    ProductID = pi.ProductID,
                                    CodeName = p.ProductCode + " - " + p.ProductName
                                };

            //var query = "SELECT pi.ProductID, ca.CategoryName "
            //    + "FROM ProductsInventory pi LEFT JOIN Categories ca "
            //    + "ON pi.ProductID = ca.ProductID "
            //    + "WHERE pi.ProductID =  " + ProductID
            //    ;
            //ViewData["Category"] = dbConn.Database.SqlQuery<ProductsInventoryCategoryVM>(query);

            ViewBag.PhotoPath = (from pi in dbConn.ProductsInventories
                                 join p in dbConn.Products on pi.ProductID equals p.ProductID
                                 where p.ProductID == ProductID
                                 select p.PhotoPath)
                                            .Take(1).SingleOrDefault();

            ViewBag.CategoryID = (from pi in dbConn.ProductsInventories
                                  join ca in dbConn.Categories on pi.CategoryID equals ca.CategoryID
                                  where pi.ProductID == ProductID
                                  select new
                                  {
                                      CategoryID = pi.CategoryID,
                                      CategoryName = ca.CategoryName
                                  }).ToList();

            //ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName", productsinventory.CategoryID);

            return View(productsinventory);
            //return View(ProductInventoryTuple);     // Test Tuple
        }

        //
        // POST: /ProductsInventory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsInventory productsinventory)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(productsinventory).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DepartemenID = new SelectList(dbConn.Customers, "DepartemenID", "CompanyName", productsinventory.DepartemenID);
            return View(productsinventory);
        }

        //
        // GET: /ProductsInventory/Delete/5

        public ActionResult Delete(int ProductID = 0, string DepartemenID = null)
        {
            ProductsInventory productsinventory = dbConn.ProductsInventories.Find(ProductID, DepartemenID);
            if (productsinventory == null)
            {
                return HttpNotFound();
            }
            return View(productsinventory);
        }

        //
        // POST: /ProductsInventory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ProductID = 0, string DepartemenID = null)
        {
            ProductsInventory productsinventory = dbConn.ProductsInventories.Find(ProductID, DepartemenID);
            dbConn.ProductsInventories.Remove(productsinventory);
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