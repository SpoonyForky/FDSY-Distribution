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
    public class FakeRentalOrderRepository : IRepository<SalesOrder>
    {
        private List<SalesOrder> repo;

        public FakeRentalOrderRepository()
        {
            repo = new List<SalesOrder>();
        }

        public void Delete(int? id)
        {
            repo.Remove(repo.Where(g => g.SalesOrderID == id).First());
        }

        public ICollection<SalesOrder> Get()
        {
            return repo;
        }

        public SalesOrder Get(int? id)
        {
            return repo.Where(s => s.SalesOrderID == id).First();
        }

        public void Post(SalesOrder _salesOrder)
        {
            repo.Add(_salesOrder);
        }

        public void Put(SalesOrder _salesOrder)
        {
            int index = repo.IndexOf(repo.Where(s => s.SalesOrderID == _salesOrder.SalesOrderID).First());
            repo[index] = _salesOrder;
        }
    }
}
