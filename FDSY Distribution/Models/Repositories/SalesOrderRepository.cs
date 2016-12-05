using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDSY_Distribution.Models.Repositories
{
    public class SalesOrderRepository : IRepository<SalesOrder>
    {
        private BeerContext db = new BeerContext();

        public void Delete(int? id)
        {
            SalesOrder so = db.SalesOrders.Find(id);
            db.SalesOrders.Remove(so);
            db.SaveChanges();
        }

        public ICollection<SalesOrder> Get()
        {
            return db.SalesOrders.ToList();
        }

        public SalesOrder Get(int? id)
        {
            return db.SalesOrders.Find(id);
        }

        public void Post(SalesOrder model)
        {
            db.SalesOrders.Add(model);
            db.SaveChanges();
        }

        public void Put(SalesOrder model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }

}
