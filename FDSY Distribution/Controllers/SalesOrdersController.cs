using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FDSY_Distribution.Models;
using FDSY_Distribution.Models.Repositories;

namespace FDSY_Distribution.Controllers
{
    public class SalesOrdersController : Controller
    {
        // private BeerContext db = new BeerContext();

        private IRepository<SalesOrder> repo;

  
        public SalesOrdersController(IRepository<SalesOrder> _repo)
        {
            this.repo = _repo;
        }

        public SalesOrdersController() : this (new SalesOrderRepository())
        {

        }



        // GET: SalesOrders
        public ActionResult Index()
        {
            return View(repo.Get());
        }

        // GET: SalesOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = repo.Get(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // GET: SalesOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesOrderID,Beer,Units,TotalPrice,Brewery_BreweryId")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                repo.Post(salesOrder);
                return RedirectToAction("Index");
            }
            return View(salesOrder);
        }

        // GET: SalesOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = repo.Get(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // POST: SalesOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesOrderID,Beer,Units,TotalPrice,Brewery_BreweryId")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                repo.Put(salesOrder);
                return RedirectToAction("Index");
            }
            return View(salesOrder);
        }

        // GET: SalesOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = repo.Get(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // POST: SalesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              //  db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
