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
        private ICollection<Bar> bars;

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
            throw new NotImplementedException();
        }

        public Bar Get(int? id)
        {
            throw new NotImplementedException();
        }

        public void Post(Bar model)
        {
            throw new NotImplementedException();
        }

        public void Put(Bar model)
        {
            throw new NotImplementedException();
        }
    }
}
