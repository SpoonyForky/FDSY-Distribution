﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FDSY_Distribution.Models;

namespace FDSY_Distribution.Controllers
{
    
    public class BarsController : Controller
    {
        //private BeerContext db = new BeerContext();

        private IRepository<Bar> repo;

        public BarsController(IRepository<Bar> _repo)
        {
            this.repo = _repo;
        }

        public BarsController() : this(new BarRepository())
        {

        }

        // GET: Bars
        public ActionResult Index()
        {
            return View(repo.Get());
        }

        // GET: Bars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bar bar = repo.Get(id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            return View(bar);
        }

        // GET: Bars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreId,Name,Address,UnitsOrdered")] Bar bar)
        {
            if (ModelState.IsValid)
            {
                repo.Post(bar);
                return RedirectToAction("Index");
            }

            return View(bar);
        }

        // GET: Bars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bar bar = repo.Get(id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            return View(bar);
        }

        // POST: Bars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreId,Name,Address,UnitsOrdered")] Bar bar)
        {
            if (ModelState.IsValid)
            {
                repo.Put(bar);
                return RedirectToAction("Index");
            }
            return View(bar);
        }

        // GET: Bars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bar bar = repo.Get(id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            return View(bar);
        }

        // POST: Bars/Delete/5
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
