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
    public class BreweriesController : Controller
    {
        //   private BeerContext db = new BeerContext();

        private IRepository<Brewery> repo;

        public BreweriesController(IRepository<Brewery> _repo)
        {
            this.repo = _repo;
        }

        public BreweriesController() : this (new BrewaryRepository())
        {

        }


        // GET: Breweries
        public ActionResult Index()
        {
            return View(repo.Get());
        }

        // GET: Breweries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brewery brewery = repo.Get(id);
            if (brewery == null)
            {
                return HttpNotFound();
            }
            return View(brewery);
        }

        // GET: Breweries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Breweries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BreweryId,Name,Address,YTDSales")] Brewery brewery)
        {
            if (ModelState.IsValid)
            {
                repo.Post(brewery);
                return RedirectToAction("Index");
            }

            return View(brewery);
        }

        // GET: Breweries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brewery brewery = repo.Get(id);
            if (brewery == null)
            {
                return HttpNotFound();
            }
            return View(brewery);
        }

        // POST: Breweries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BreweryId,Name,Address,YTDSales")] Brewery brewery)
        {
            if (ModelState.IsValid)
            {
                repo.Put(brewery);
                return RedirectToAction("Index");
            }
            return View(brewery);
        }

        // GET: Breweries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brewery brewery = repo.Get(id);
            if (brewery == null)
            {
                return HttpNotFound();
            }
            return View(brewery);
        }

        // POST: Breweries/Delete/5
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
