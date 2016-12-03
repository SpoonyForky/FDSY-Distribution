using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSY_Distribution.Models.Repositories
{
    public class BrewaryRepository : IRepository<Brewery>
    {
        private BeerContext db = new BeerContext();

        public void Delete(int? id)
        {
            Brewery brew = db.Breweries.Find(id);
            db.Breweries.Remove(brew);
            db.SaveChanges();
        }

        public ICollection<Brewery> Get()
        {
            return db.Breweries.ToList();
        }

        public Brewery Get(int? id)
        {
            return db.Breweries.Find(id);

        }

        public void Post(Brewery model)
        {
            db.Breweries.Add(model);
            db.SaveChanges();
        }

        public void Put(Brewery model)
        {

            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}