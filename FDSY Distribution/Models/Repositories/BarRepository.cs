using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSY_Distribution.Models
{
    public class BarRepository : IRepository<Bar>
    {
        private BeerContext db = new BeerContext();

        public void Delete(int? id)
        {
            Bar bar = db.Bars.Find(id);
            db.Bars.Remove(bar);
            db.SaveChanges();
        }

        public ICollection<Bar> Get()
        {
            return db.Bars.ToList();
        }

        public Bar Get(int? id)
        {
            return db.Bars.Find(id);
        }

        public void Post(Bar model)
        {
            db.Bars.Add(model);
            db.SaveChanges();
        }

        public void Put(Bar model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}