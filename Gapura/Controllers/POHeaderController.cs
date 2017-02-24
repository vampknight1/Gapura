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
    public class POHeaderController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /POHeader/

        public ActionResult Index()
        {
            return View(dbConn.POHeaders.ToList());
        }

        ///////////////-------------- Load Data by JQuery Fir 26102016 -----------------/////////////
        public ActionResult LoadData()
        {
            //using (YSIDGAEntitiesConn dc = new YSIDGAEntitiesConn())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                dbConn.Configuration.LazyLoadingEnabled = false;

                var data = dbConn.SPR_POHeader().ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        ///////////////-----------End Load Data by JQuery Fir 26102016 -----------------/////////////

        //
        // GET: /POHeader/Details/5

        public ActionResult Details(int id = 0)
        {
            POHeader poheader = dbConn.POHeaders.Find(id);
            if (poheader == null)
            {
                return HttpNotFound();
            }
            return View(poheader);
        }

        //
        // GET: /POHeader/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /POHeader/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(POHeader poheader)
        {
            if (ModelState.IsValid)
            {
                dbConn.POHeaders.Add(poheader);
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poheader);
        }

        //
        // GET: /POHeader/Edit/5

        public ActionResult Edit(int id = 0)
        {
            POHeader poheader = dbConn.POHeaders.Find(id);
            if (poheader == null)
            {
                return HttpNotFound();
            }

            ViewBag.PONo = poheader.PONo;
            ViewData["PODate"] = DateTime.Now.ToString("yyyy/MM/dd");
            ViewData["RequestNo"] = (from rh in dbConn.RequestHeaders
                                                    where rh.RequestID == id
                                                    select rh.RequestNo
                                                   ).Take(1).SingleOrDefault();
            ViewData["ReffNo"] = poheader.ReffNo;
            ViewData["RequestDate"] = poheader.RequestDate.Date.ToString("yyyy/MM/dd");
            ViewData["RequiredDate"] = poheader.RequiredDate.Date.ToString("yyyy/MM/dd");
            ViewBag.Remarks = poheader.Remarks;
            ViewBag.DepartemenID = new SelectList(dbConn.Departements, "DepartemenID", "DepartemenName", poheader.DepartemenID);
            ViewBag.RequestTypeID = new SelectList(dbConn.MasterRequestTypes, "ID", "RequestType", poheader.RequestTypeID);
            ViewBag.CurrencyID = new SelectList(dbConn.MasterCurrencies, "ID", "CurrencyCode", poheader.CurrencyID);
            ViewBag.AssetsTypeID = new SelectList(dbConn.MasterAssetsTypes, "ID", "AssetsType", poheader.AssetsTypeID);
            ViewBag.EmployeeID = new SelectList(dbConn.Employees, "EmployeeID", "LastName", poheader.EmployeeID);
            ViewBag.MgrID = new SelectList(dbConn.Employees, "EmployeeID", "LastName", poheader.MgrID);
            ViewBag.GAMgrID = new SelectList(dbConn.Employees, "EmployeeID", "LastName", poheader.GAMgrID);
            ViewBag.GMID = new SelectList(dbConn.Employees, "EmployeeID", "LastName", poheader.GMID);
            ViewData["TotalRequest"] = poheader.TotalRequest;
            ViewData["TotalPrice"] = poheader.TotalPrice;
            ViewData["PODetails"] = dbConn.Database.SqlQuery<PODetailListVM>("EXEC SPR_PODetail {0}", id).ToList();

            return View(poheader);
        }

        //
        // POST: /POHeader/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(POHeader poheader)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(poheader).State = EntityState.Modified;
                dbConn.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.PONo = poheader.PONo;
            //ViewData["PODate"] = DateTime.Now.ToString("yyyy/MM/dd");
            //ViewData["RequestNo"] = (from rh in dbConn.RequestHeaders
            //                         where rh.RequestID == id
            //                         select rh.RequestNo
            //                        ).Take(1).SingleOrDefault();
            //ViewData["ReffNo"] = poheader.ReffNo;
            //ViewData["RequestDate"] = poheader.RequestDate.Date.ToString("yyyy/MM/dd");
            //ViewData["RequiredDate"] = poheader.RequiredDate.Date.ToString("yyyy/MM/dd");
            //ViewBag.Remarks = poheader.Remarks;
            ViewBag.DepartemenID = new SelectList(dbConn.Departements, "DepartemenID", "DepartemenName", poheader.DepartemenID);
            ViewBag.RequestTypeID = new SelectList(dbConn.MasterRequestTypes, "ID", "RequestType", poheader.RequestTypeID);
            ViewBag.CurrencyID = new SelectList(dbConn.MasterCurrencies, "ID", "CurrencyCode", poheader.CurrencyID);
            ViewBag.AssetsTypeID = new SelectList(dbConn.MasterAssetsTypes, "ID", "AssetsType", poheader.AssetsTypeID);
            ViewBag.EmployeeID = new SelectList(dbConn.Employees, "EmployeeID", "LastName", poheader.EmployeeID);
            ViewBag.MgrID = new SelectList(dbConn.Employees, "EmployeeID", "LastName", poheader.MgrID);
            ViewBag.GAMgrID = new SelectList(dbConn.Employees, "EmployeeID", "LastName", poheader.GAMgrID);
            ViewBag.GMID = new SelectList(dbConn.Employees, "EmployeeID", "LastName", poheader.GMID);
            //ViewData["TotalRequest"] = poheader.TotalRequest;
            //ViewData["TotalPrice"] = poheader.TotalPrice;
            //ViewBag.PODetails = poheader.PODetails.ToList();

            return View(poheader);
        }

        //
        // GET: /POHeader/Delete/5

        public ActionResult Delete(int id = 0)
        {
            POHeader poheader = dbConn.POHeaders.Find(id);
            if (poheader == null)
            {
                return HttpNotFound();
            }
            return View(poheader);
        }

        //
        // POST: /POHeader/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POHeader poheader = dbConn.POHeaders.Find(id);
            dbConn.POHeaders.Remove(poheader);
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