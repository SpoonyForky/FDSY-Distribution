using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDSY_Distribution.Models.Repositories;
using FDSY_Distribution.Controllers;
using FDSY_Distribution.Controllers.ApiControllers;
using FDSY_Distribution.Models.ViewModels;
using FDSY_Distribution.Models;

namespace FDSY_Distribution.Tests.FakeRepositories
{
    public class FakeSalesOrderRepository : IRepository<SalesOrder>
    {
        private List<SalesOrder> so;

        public FakeSalesOrderRepository()
        {
            so = new List<SalesOrder>();
        }

        public void Delete(int? id)
        {
            SalesOrder mySale = so.Where(g => g.SalesOrderID == id).First();
            so.Remove(mySale);
        }

        public ICollection<SalesOrder> Get()
        {
            return so;
        }

        public SalesOrder Get(int? id)
        {
            return new SalesOrder() { SalesOrderID = (int)id };
        }

        public void Post(SalesOrder model)
        {
            so.Add(model);
        }

        public void Put(SalesOrder model)
        {
            so.Where(d => d.SalesOrderID == model.SalesOrderID).First().TotalPrice = "4000";
        }
    }
}
