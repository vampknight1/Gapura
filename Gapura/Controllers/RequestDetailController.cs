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
    public class RequestDetailController : Controller
    {
        private YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn();

        //
        // GET: /RequestDetail/

        public ActionResult Index(int id)
        {
            ////return View(dbConn.RequestDetails.Where(rd => rd.RequestID == id).ToList());

            ViewData["ProductName"] = (from rd in dbConn.RequestDetails
                                       join p in dbConn.Products on rd.ProductID equals p.ProductID
                                       where rd.RequestID == id
                                       select p.ProductName).ToList();

            ViewData["UnitName"] = (from rd in dbConn.RequestDetails
                                    join p in dbConn.MasterUnits on rd.UnitID equals p.UnitID
                                    where rd.RequestID == id
                                    select p.UnitName).ToList();

            //var RequestDetailList = (from rd in dbConn.RequestDetails                                 // Using Linq
            //                         join p in dbConn.Products on rd.ProductID equals p.ProductID
            //                         join mu in dbConn.MasterUnits on rd.UnitID equals mu.UnitID
            //                         where rd.RequestID == id
            //                         select new
            //                         {
            //                             RequestDetailID = rd.RequestDetailID,
            //                             RequestID = rd.RequestID,
            //                             ProductName = p.ProductName,
            //                             UnitPrice = rd.UnitPrice,
            //                             UnitName = mu.UnitName,
            //                             Quantity = rd.Quantity,
            //                             Amount = rd.Amount,
            //                             Remarks = rd.Remarks
            //                         }).Select(a => new RequestDetailListVM
            //                         {
            //                             RequestDetailID = a.RequestDetailID,
            //                             RequestID = a.RequestID,
            //                             ProductName = a.ProductName,
            //                             UnitPrice = a.UnitPrice,
            //                             UnitName = a.UnitName,
            //                             Quantity = a.Quantity,
            //                             Amount = a.Amount,
            //                             Remarks = a.Remarks
            //                         }).ToList();

            //return View(RequestDetailList);
            
            return View     // using SP
            (
                dbConn.Database.SqlQuery<RequestDetailListVM>("EXEC SPR_RequestDetail {0}", id).ToList()
            );
        }

        //
        // GET: /RequestDetail/Details/5

        public ActionResult Details(int id = 0)
        {
            RequestDetail requestdetail = dbConn.RequestDetails.Find(id);
            if (requestdetail == null)
            {
                return HttpNotFound();
            }
            return View(requestdetail);
        }

        //
        // GET: /RequestDetail/Create

        public ActionResult Create()
        {
            //return View();
            // Test Bulk Req. Detail
            List<RequestDetail> reqdet = new List<RequestDetail> { new RequestDetail { RequestDetailID = 0, RequestID = 0, ProductID = 0, UnitPrice = 0, UnitID = 0, Quantity = 0, Amount = 0, Remarks = "" } };
            return View(reqdet);
        }

        //
        // POST: /RequestDetail/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(RequestDetail requestdetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        dbConn.RequestDetails.Add(requestdetail);
        //        dbConn.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(requestdetail);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(List<RequestDetail> reqdet)
        {
            if (ModelState.IsValid)
            {
                using (YSIDGAEntitiesConn dbConn = new YSIDGAEntitiesConn())
                {
                    foreach (var i in reqdet)
                    {
                        dbConn.RequestDetails.Add(i);
                    }
                    dbConn.SaveChanges();
                    ViewBag.Message = "Request Item Successfully saved !!";
                    ModelState.Clear();
                    reqdet = new List<RequestDetail> { new RequestDetail { RequestDetailID = 0, RequestID = 0, ProductID = 0, UnitPrice = 0, UnitID = 0, Quantity = 0, Amount = 0, Remarks = "" } };
                }
            }
            return View(reqdet);
        }

        //
        // GET: /RequestDetail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RequestDetail requestdetail = dbConn.RequestDetails.Find(id);
            if (requestdetail == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProductID = new SelectList(dbConn.Products, "ProductID", "ProductName", requestdetail.ProductID);
            ViewBag.UnitID = new SelectList(dbConn.MasterUnits, "UnitID", "UnitName", requestdetail.UnitID);

            return View(requestdetail);
        }

        //
        // POST: /RequestDetail/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RequestDetail requestdetail)
        {
            if (ModelState.IsValid)
            {
                dbConn.Entry(requestdetail).State = EntityState.Modified;
                dbConn.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(Request.UrlReferrer.ToString());
            }

            ViewBag.ProductID = new SelectList(dbConn.Products, "ProductID", "ProductName", requestdetail.ProductID);
            ViewBag.UnitID = new SelectList(dbConn.MasterUnits, "UnitID", "UnitName", requestdetail.UnitID);

            return View(requestdetail);
        }

        //
        // GET: /RequestDetail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RequestDetail requestdetail = dbConn.RequestDetails.Find(id);
            if (requestdetail == null)
            {
                return HttpNotFound();
            }
            return View(requestdetail);
        }

        //
        // POST: /RequestDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestDetail requestdetail = dbConn.RequestDetails.Find(id);
            dbConn.RequestDetails.Remove(requestdetail);
            dbConn.SaveChanges();
            //return RedirectToAction("Index");
            //return Redirect(Request.UrlReferrer.ToString());
            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            dbConn.Dispose();
            base.Dispose(disposing);
        }
    }
}