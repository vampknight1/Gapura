﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gapura.Models;
using System.IO;

namespace Gapura.Controllers
{
    public class ProductsController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /Products/

        public ActionResult Index()
        {
            var products = dbConn.Products.Include(p => p.Category).Include(p => p.Supplier);
            return View(products.ToList());
        }

        ///////////////-------------- Load Data by JQuery Fir 26102016 -----------------/////////////
        public ActionResult LoadData()
        {
            //using (YSIDGAEntitiesConn dc = new YSIDGAEntitiesConn())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                dbConn.Configuration.LazyLoadingEnabled = false;
                //var data = dbConn.Products.OrderBy(p => p.ProductName).ToList();      //default way
                //var data = from p in dbConn.Products
                //           join ca in dbConn.Categories on p.CategoryID equals ca.CategoryID
                //           join s in dbConn.Suppliers on p.SupplierID equals s.SupplierID
                //           orderby p.ProductName
                //           select new { p.ProductID, p.ProductCode, ca.CategoryName, p.ProductName, 
                //                        s.CompanyName, p.QuantityPerUnit, p.UnitPrice, 
                //                        p.ReorderLevel, p.Discontinued, p.Specs };
                ////List<Product> list_product = dbConn.ToList<Product>();                //jika diperlukan buat convert to List

                var Products = dbConn.SPR_Products().ToList();
                return Json(new { data = Products }, JsonRequestBehavior.AllowGet);
            }
        }
        ///////////////-----------End Load Data by JQuery Fir 26102016 -----------------/////////////

        public JsonResult Upload(Product product)
        {

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;

                foreach (string filePhoto in Request.Files)
                {
                    //To save file, use SaveAs method
                    file.SaveAs(Server.MapPath("~/UploadFiles/Item/") + fileName); //File will be saved in exp. root "~/"

                    var postedFile = Request.Files[filePhoto];
                    //postedFile.SaveAs(Server.MapPath("~/img/Photo/") + Path.GetFileName(postedFile.FileName));
                    product.PhotoPath = "~/UploadFiles/Item/" + Path.GetFileName(postedFile.FileName);
                }

                ////To save file, use SaveAs method
                //file.SaveAs(Server.MapPath("~/img/Photo/") + fileName); //File will be saved in exp. root "~/"
            }
            return Json("Uploaded " + Request.Files.Count + " files");
        }

        public JsonResult getProducts()
        {
            //dbConn.Configuration.LazyLoadingEnabled = false;
            List<Product> Products = new List<Product>();
            using (YSIDGAEntitiesConn ItemConn = new YSIDGAEntitiesConn())
            {
                ItemConn.Configuration.LazyLoadingEnabled = false;
                //Products = ItemConn.Products.SqlQuery("SELECT ProductID, ProductName FROM Products").ToList();
                Products = ItemConn.Products.OrderBy(p => p.ProductName).ToList();
                
            }
            //var Products = dbConn.SPR_Products().ToList();
            return new JsonResult { Data = Products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult getProduct(string term)
        {
            var routeList = dbConn.Products.Where(r => r.ProductName.Contains(term))
                    .Take(6)
                    .Select(r => new { value = r.ProductID, label = r.ProductName });
            return Json(routeList, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = dbConn.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            ViewData["FirstInputDate"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            ViewBag.UnitID = new SelectList(dbConn.MasterUnits, "UnitID", "UnitName");
            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(dbConn.Suppliers, "SupplierID", "CompanyName");

            return View();
        }

        //
        // POST: /Products/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (Request.Files.Count > 0)
            {
                //HttpPostedFileBase file = Request.Files[0];
                foreach (string file in Request.Files)
                {
                    var postedFile = Request.Files[file];
                    //postedFile.SaveAs(Server.MapPath("~/img/Photo/") + Path.GetFileName(postedFile.FileName));
                    product.PhotoPath = "~/UploadFiles/Item/" + Path.GetFileName(postedFile.FileName);
                }
            }
            else
            {
                ViewBag.Message = "Please select the file !";
            }

            if (ModelState.IsValid)
            {
                dbConn.Products.Add(product);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitID = new SelectList(dbConn.MasterUnits, "UnitID", "UnitName", product.UnitID);
            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(dbConn.Suppliers, "SupplierID", "CompanyName", product.SupplierID);

            return View(product);
        }

        //
        // GET: /Products/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = dbConn.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewData["ProductName"] = product.ProductName;
            ViewBag.UnitID = new SelectList(dbConn.MasterUnits, "UnitID", "UnitName", product.UnitID);
            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(dbConn.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            ViewData["FirstInputDate"] = product.FirstInputDate.ToString();

            return View(product);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string oldPhotoPath = product.PhotoPath;
                    HttpPostedFileBase file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/UploadFiles/Item/"), fileName);
                        file.SaveAs(path);

                        product.PhotoPath = "/UploadFiles/Item/" + file.FileName;
                        string fullPath = Request.MapPath("~" + oldPhotoPath);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                    }
                    else
                    {
                        ViewData["PhotoPath"] = product.PhotoPath;
                    }
                }

                dbConn.Entry(product).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnitID = new SelectList(dbConn.MasterUnits, "UnitID", "UnitName", product.UnitID);
            ViewBag.CategoryID = new SelectList(dbConn.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(dbConn.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        //
        // GET: /Products/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = dbConn.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = dbConn.Products.Find(id);
            dbConn.Products.Remove(product);
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