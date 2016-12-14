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
    public class BeersController : Controller
    {
        private BeerContext db = new BeerContext();
        private IRepository<Beer> repo;


        public BeersController(IRepository<Beer> _repo)
        {
            this.repo = _repo;
        }

        public BeersController() : this(new BeerRepository())
        {

        }

        // GET: Beers
        public ActionResult Index()
        {
            return View(repo.Get());
        }

        // GET: Beers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = repo.Get(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // GET: Beers/Create
        public ActionResult Create()
        {
            ViewBag.BreweryBreweryId = new SelectList(db.Breweries, "BreweryId", "Name");
            return View();
        }

        // POST: Beers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BeerId,BreweryBreweryId,UnitPrice,Name,Type,ABV")] Beer beer)
        {
            if (ModelState.IsValid)
            {
               repo.Post(beer);
               return RedirectToAction("Index");
            }

            ViewBag.BreweryBreweryId = new SelectList(db.Breweries, "BreweryId", "Name", beer.BreweryBreweryId);
            return View(beer);
        }

        // GET: Beers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = repo.Get(id);
            ViewBag.BreweryBreweryId = new SelectList(db.Breweries, "BreweryId", "Name", beer.BreweryBreweryId);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // POST: Beers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BeerId,BreweryBreweryId,UnitPrice,Name,Type,ABV")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                repo.Put(beer);
                return RedirectToAction("Index");
            }
            return View(beer);
        }

        // GET: Beers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = repo.Get(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // POST: Beers/Delete/5
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
             //   db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
