using FDSY_Distribution.Models;
using FDSY_Distribution.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDSY_Distribution.Controllers
{
    /// <summary>
    /// Controller for Home
    /// </summary>
    public class HomeController : Controller
    {

        private IRepository<Beer> repo;

        public HomeController(IRepository<Beer> _repo)
        {
            this.repo = _repo;
        }

        public HomeController() : this(new BeerRepository()) { }

        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            Random rnd = new Random();
            List<Beer> _beers = repo.Get().ToList();
            int beerIndex = rnd.Next(0, _beers.Count);
            return View(_beers[beerIndex]);

        }
    }
}
