using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDSY_Distribution.Models;

namespace FDSY_Distribution.Tests.FakeRepositories
{
    public class FakeBarRepository : IRepository<Bar>
    {
        private List<Bar> bars;

        public FakeBarRepository()
        {
            bars = new List<Bar>();
        }

        public void Delete(int? id)
        {
            Bar cheers = bars.Where(g => g.StoreId == id).First();
            bars.Remove(cheers);
        }

        public ICollection<Bar> Get()
        {
            return bars;
        }

        public Bar Get(int? id)
        {
            return new Bar() { StoreId = (int)id };

        }

        public void Post(Bar model)
        {
            bars.Add(model);
        }

        public void Put(Bar model)
        {
            bars.Where(d => d.StoreId == model.StoreId).First().Name = "Monahans";
            
        }
    }
}
