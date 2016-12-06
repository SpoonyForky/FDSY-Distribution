using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSY_Distribution.Models.Repositories
{
    public class BeerRepository : IRepository<Beer>
    {
        private BeerContext db = new BeerContext();

        public void Delete(int? id)
        {
            Beer b = db.Beers.Find(id);
            db.Beers.Remove(b);
            db.SaveChanges();
        }

        public ICollection<Beer> Get()
        {
            return db.Beers.ToList();
        }

        public Beer Get(int? id)
        {
            return db.Beers.Find(id);
        }

        public void Post(Beer model)
        {
            db.Beers.Add(model);
            db.SaveChanges();
        }

        public void Put(Beer model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}